import React from "react";
import { makeStyles } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';

const resultRows_prihod = ['Статьи прихода', 'кДж/кг', '%'];
const resultRows_rashod = ['Статьи расхода', 'кДж/кг', '%'];

const useStyles = makeStyles({
    table: {
        minWidth: 410,
    },
});

function createData(name, first, second) {
    return { name, first, second };
}

export const HeatBalance = ({result}) => {
    const classes = useStyles();
    console.log(result);

    const rows_prihod = [
        createData('Горение кокса', result.c66, result.c66_persent),
        createData('Тепло нагретого дутья', result.c71, result.c71_persent),
        createData('Тепло конверсии газа', result.c73, result.c73_persent),
        createData('Итого приход тепла', result.sum, result.sum_persent),
    ];

    const rows_rashod = [
        createData('Прямое восстановление оксидов железа', result.c81, result.c81_persent),
        createData('Прямое восстановление примесей чугуна', result.c83, result.c83_persent),
        createData('Расход тепла на десульфурацию чугуна', result.c85, result.c85_persent),
        createData('Восстановление оксидов железа водородом', result.c87, result.c87_persent),
        createData('Тепло, уносимое чугуном', result.c89, result.c89_persent),
        createData('Тепло, уносимое шлаком', result.c91, result.c91_persent),
        createData('Разложение влаги дутья', result.c93, result.c93_persent),
        createData('Расход тепла на разложение известняка', result.c95, result.c95_persent),
        createData('Расход тепла на разложение влаги шихты', result.c97, result.c97_persent),
        createData('Тепло, уносимое колошниковым газом ', result.c104, result.c104_persent),
    ];

    return (

        <div className={'DP-work__inputs result-table'}>
            <h5>Тепловой баланс</h5>

            <TableContainer component={Paper}>
                <Table className={classes.table} aria-label="simple table">
                    <TableHead>
                        <TableRow>
                            {resultRows_prihod.map((item, index) => <TableCell key={index} align={index === 0 ? "left" : 'center' }>{item}</TableCell>)}
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {rows_prihod.map((row, index) => (
                            <TableRow key={index}>
                                <TableCell component="th" scope="row" width={'60%'}>
                                    {row.name}
                                </TableCell>
                                <TableCell align="center">{row.first}</TableCell>
                                <TableCell align="center">{row.second}</TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
            <br/>{/* {//'-----------------------------------------------'}*/}
            <TableContainer component={Paper}>
                <Table className={classes.table} aria-label="simple table">
                    <TableHead>
                        <TableRow>
                            {resultRows_rashod.map((item, index) => <TableCell key={index} align={index === 0 ? "left" : 'center' }>{item}</TableCell>)}
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {rows_rashod.map((row, index) => (
                            <TableRow key={index}>
                                <TableCell component="th" scope="row" width={'60%'}>
                                    {row.name}
                                </TableCell>
                                <TableCell align="center">{row.first}</TableCell>
                                <TableCell align="center">{row.second}</TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
        </div>
    )
}


