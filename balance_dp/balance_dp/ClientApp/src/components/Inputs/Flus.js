import React from "react";
import {makeStyles} from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';

const columns = ['Известняк', 'Платиковый шпат', 'Кварцит', 'Шлак фракц.'];
const resultRows = ['Наименование', 'Расход, кг/т чугуна', 'Cao', 'SiO2', 'Al2O3', 'MgO', 'TiO2', 'MnO', 'P', 'S']

const useStyles = makeStyles({
    table: {
        minWidth: 500,
    },
});

function createData (name, first, second, third, fourth, fifth, sixth, seventh, eighth, ninth) {
    return {name, first, second, third, fourth, fifth, sixth, seventh, eighth, ninth};
}

function getInput (name, value, onChangeInput, key) {
    return <input key={`${name}-${key}`} id={`${name}`} type="text" value={value} onChange={onChangeInput}/>
}

function createRow () {
    let counter = 0;
    return function (name, param, onChangeInput, discr) {
        const paramArray = [];
        paramArray.push(columns[counter])
        for (let key in param[discr]) {
            paramArray.push(getInput(name + `-${discr}-` + key, param[discr][key], onChangeInput, key ));
        }
        counter++;
        console.log(paramArray)
        return paramArray;
    }
}

function createRows (name, params, onChangeInput) {
    const rowsArray = [];
    const generator = createRow()
    rowsArray.push(createData(...generator(name, params, onChangeInput, 'Limestone')))
    rowsArray.push(createData(...generator(name, params, onChangeInput, 'Fluospat')))
    rowsArray.push(createData(...generator(name, params, onChangeInput, 'Quartzite')))
    rowsArray.push(createData(...generator(name, params, onChangeInput, 'Slug')))
    return rowsArray;
}

export const Flus = ({name, params, onChangeInput}) => {
    const classes = useStyles();
    const rows = createRows(name, params, onChangeInput);
    return (
        <div className={'DP-work__inputs flus-table'}>
            <h5 style={{textAlign:'center'}}>Ввод видов и составов загружаемых в печь флюсов</h5>
            <TableContainer component={Paper}>
                <Table className={classes.table} aria-label="a dense table">
                    <TableHead>
                        <TableRow>
                            {resultRows.map((item, index) => <TableCell key={index} align={index === 0 ? "left" : 'center'}>{item}</TableCell>)}
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {rows.map((row, index) => (
                            <TableRow key={index}>
                                <TableCell component="th" scope="row">
                                    {row.name}
                                </TableCell>
                                <TableCell align="center">{row.first}</TableCell>
                                <TableCell align="center">{row.second}</TableCell>
                                <TableCell align="center">{row.third}</TableCell>
                                <TableCell align="center">{row.fourth}</TableCell>
                                <TableCell align="center">{row.fifth}</TableCell>
                                <TableCell align="center">{row.sixth}</TableCell>
                                <TableCell align="center">{row.seventh}</TableCell>
                                <TableCell align="center">{row.eighth}</TableCell>
                                <TableCell align="center">{row.ninth}</TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
        </div>
    )
}


