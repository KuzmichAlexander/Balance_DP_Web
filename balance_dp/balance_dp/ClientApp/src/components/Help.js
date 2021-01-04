import React from "react";
import Paper from "@material-ui/core/Paper";
import Table from "@material-ui/core/Table";
import TableHead from "@material-ui/core/TableHead";
import TableRow from "@material-ui/core/TableRow";
import TableCell from "@material-ui/core/TableCell";
import TableBody from "@material-ui/core/TableBody";
import TableContainer from "@material-ui/core/TableContainer";
import {makeStyles} from "@material-ui/core/styles";

const useStyles = makeStyles({
    table: {
        minWidth: 250,
        rowGap: 10
    },
});

function createData(first, second) {
    return {first, second};
}

const rowNames = ['Месяц', 'Влажность г/м3'];
const rows = [createData('Январь', 1.5),
    createData('Февраль', 1.5),
    createData('Март', 2),
    createData('Апрель', 3.5),
    createData('Май', 7),
    createData('Июнь', 11),
    createData('Июль', 11),
    createData('Август', 11),
    createData('Сентябрь', 7),
    createData('Октябрь', 5.5),
    createData('Ноябрь', 3),
    createData('Декабрь', 2)
];

export const Help = () => {
    const classes = useStyles();
   
    return (
        <div className='content'>
            <h1>Справочная информация</h1>
            <h4>Влияние месяца на коэффициент сезонный влажности:</h4>
            <div className={'help-table__container'}>
                <TableContainer component={Paper}>
                    <Table className={classes.table} size="small" aria-label="simple table">
                        <TableHead>
                            <TableRow>
                                {rowNames.map((item, index) => <TableCell key={index}
                                                                          align={index === 0 ? "left" : 'center'}>{item}</TableCell>)}
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {rows.map((row, index) => (
                                <TableRow key={index}>
                                    <TableCell align="left">{row.first}</TableCell>
                                    <TableCell align="center">{row.second}</TableCell>
                                </TableRow>
                            ))}
                        </TableBody>
                    </Table>
                </TableContainer>
            </div>
            <h4>Ознакомится с алгоритмом калькулятора можно скачав файлы:</h4>
             </div>
    )
}
