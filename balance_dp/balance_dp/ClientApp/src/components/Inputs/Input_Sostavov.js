import React from "react";
import {makeStyles} from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';

const columns = ['Агломерат а/ф №2', 'Агломерат а/ф №3', 'Агломерат а/ф №4', 'Агломерат а/ф №5', 'Агломерат неочищенный', 'Агломерат яма', 'Окатыши Соколовские', 'Окатыши Лебединские', 'Окатыши Качканарские', 'Окатыши Михайловские', 'Сварочный шлак', 'Королек', 'Доменный присад', 'Руда Марг. Низгуловская', 'Руда Марг. Жайремская'];
const resultRows = ['Наименование', 'Расход, кг/т чугуна', 'Fe', 'FeO', 'Fe2O3', 'SiO2', 'AlO3', 'CaO', 'MgO', 'P', 'S', 'MnO', 'Zn', 'Пмпп', 'H20', 'TiO2', 'Cr'];

const useStyles = makeStyles({
    table: {
        minWidth: 500,
    },
});

function createData (name, first, second, third, fourth, fifth, sixth, seventh, eighth, ninth, tenth, eleventh, twelveth, thirteenth, fourteenth, fifteenth, sixteenth) {
    return {name, first, second, third, fourth, fifth, sixth, seventh, eighth, ninth, tenth, eleventh, twelveth, thirteenth, fourteenth, fifteenth, sixteenth};
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
        return paramArray;
    }
}

function createRows (name, params, onChangeInput) {
    const rowsArray = [];
    const generator = createRow()
    rowsArray.push(createData(...generator(name, params, onChangeInput, 'A9_Aglomerat2')))
    rowsArray.push(createData(...generator(name, params, onChangeInput, 'A10_Aglomerat3')))
    rowsArray.push(createData(...generator(name, params, onChangeInput, 'A11_Aglomerat4')))
    rowsArray.push(createData(...generator(name, params, onChangeInput, 'A12_Aglomerat5')))
    rowsArray.push(createData(...generator(name, params, onChangeInput, 'A13_AglomeratNotCleared')))
    rowsArray.push(createData(...generator(name, params, onChangeInput, 'A14_AglomeratYama')))
    rowsArray.push(createData(...generator(name, params, onChangeInput, 'A15_Okat_Sokolov')))
    rowsArray.push(createData(...generator(name, params, onChangeInput, 'A16_Okat_Lebed')))
    rowsArray.push(createData(...generator(name, params, onChangeInput, 'A17_Okat_Kachkan')))
    rowsArray.push(createData(...generator(name, params, onChangeInput, 'A18_Okat_Mikhay')))
    rowsArray.push(createData(...generator(name, params, onChangeInput, 'A19_Welding_slag')))
    rowsArray.push(createData(...generator(name, params, onChangeInput, 'A20_Korolek')))
    rowsArray.push(createData(...generator(name, params, onChangeInput, 'A21_Domen_prisad')))
    rowsArray.push(createData(...generator(name, params, onChangeInput, 'A22_Ruda_Mn_Nizgul')))
    rowsArray.push(createData(...generator(name, params, onChangeInput, 'A23_Ruda_Mn_Jairem')))
    return rowsArray;
}

export const InputSostavov = ({name, params, onChangeInput}) => {
    console.log(name, params)
    const classes = useStyles();
    const rows = createRows(name, params, onChangeInput);
    return (
        <div className={'DP-work__inputs flus-table'}>
            <h5 style={{textAlign:'center'}}>Ввод составов загруженных ЖРМ</h5>
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
                                <TableCell align="center">{row.tenth}</TableCell>
                                <TableCell align="center">{row.eleventh}</TableCell>
                                <TableCell align="center">{row.twelveth}</TableCell>
                                <TableCell align="center">{row.thirteenth}</TableCell>
                                <TableCell align="center">{row.fourteenth}</TableCell>
                                <TableCell align="center">{row.fifteenth}</TableCell>
                                <TableCell align="center">{row.sixteenth}</TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
        </div>
    )
}


