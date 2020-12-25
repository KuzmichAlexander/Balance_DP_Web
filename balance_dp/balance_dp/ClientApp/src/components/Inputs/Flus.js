import React from "react";
import {makeStyles} from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import {OneInput} from "./OneInput";

const resultRows = ['Название', 'Известняк', 'Платиковый шпат', 'Кварцит', 'Шлак фракц.'];
const columns = ['Расход, кг/т чугуна', 'Cao', 'SiO2', 'Al2O3', 'MgO', 'TiO2', 'MnO', 'P', 'S']

const useStyles = makeStyles({
    table: {
        minWidth: 500,
    },
});

function createData (name, first, second, third, fourth) {
    return {name, first, second, third, fourth};
}
// [
//     createData('Расход, кг/т чугуна', result.heatOfBurningCocks, result.heatOfBurningCocks_persent),
//     createData('CaO', result.heatCountBlowin, result.heatCountBlowing_persent),
//     createData('SiO2', result.heatCountOfConversion, result.heatCountOfConversion_persent),
//     createData('Итого приход тепла', result.sum, result.sum_persent),
// ]
function getInput (name, value, onChangeInput, key) {
    return <input key={`${name}-${key}`} id={`${name}`} type="text" value={value} onChange={onChangeInput}/>
}

function createRows (name, params, onChangeInput) {
    const rowsArray = [];
    let counter = 0
    for (let key in params.Limestone) {
        console.log(key)
        rowsArray.push(
            createData(columns[counter],
                getInput(name + '-Limestone-' + key, params['Limestone'][key], onChangeInput, key ),
                getInput(name + '-Fluospat-' + key, params['Fluospat'][key], onChangeInput, key ),
                getInput(name + '-Quartzite-' + key, params['Quartzite'][key], onChangeInput, key ),
                getInput(name + '-Slug-' + key, params['Slug'][key], onChangeInput, key ))
        )
        counter++;
    }
    return rowsArray;
}

export const Flus = ({name, params, onChangeInput}) => {
    const classes = useStyles();
    const rows = createRows(name, params, onChangeInput);

    return (
        <div className={'DP-work__inputs flus-table'}>
            <h5>Ввод видов и составов загружаемых в печь флюсов</h5>
            <TableContainer component={Paper}>
                <Table className={classes.table} aria-label="simple table">
                    <TableHead>
                        <TableRow>
                            {resultRows.map((item, index) => <TableCell width={'20%'} key={index} align={index === 0 ? "left" : 'center'}>{item}</TableCell>)}
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {rows.map((row, index) => (
                            <TableRow key={index}>
                                <TableCell component="th" scope="row" padding={0}>
                                    {row.name}
                                </TableCell>
                                <TableCell width={'20%'} align="center">{row.first}</TableCell>
                                <TableCell width={'20%'} align="center">{row.second}</TableCell>
                                <TableCell width={'20%'} align="center">{row.third}</TableCell>
                                <TableCell width={'20%'} align="center">{row.fourth}</TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
        </div>
    )
}


