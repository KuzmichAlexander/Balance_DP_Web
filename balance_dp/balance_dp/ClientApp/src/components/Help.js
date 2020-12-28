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

const names = {
    WORD: 'Word',
    EXCEL: 'Excel'
}


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
    const getFile = (e) => {
        e.target.value === names.EXCEL ?
            document.querySelector('.excel-link').click() :
            document.querySelector('.word-link').click();
    };
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
            <input type="button" value={names.EXCEL} className={'button_Excel content-help__button'} onClick={getFile}/>
            <input type="button" value={names.WORD} className={'button_Word content-help__button'} onClick={getFile}/>

            <a className={'excel-link'}
               href="https://vk.com/docs?act=doc_preview_link&user_id=325620667&time=1609146209&oid=325620667&did=581844500&hash=d9f99b920724d178d6&dl=1"></a>
            <a className={'word-link'}
               href="https://vk.com/docs?act=doc_preview_link&user_id=325620667&time=1609149135&oid=6799642&did=575673535&hash=232eb392bc369070f4&dl=1"></a>
        </div>
    )
}
