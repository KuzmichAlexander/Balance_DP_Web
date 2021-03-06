import React from "react";
import {makeStyles} from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import {resultRows_prihod, resultRows_rashod, resultRows_prihod_heat, resultRows_rashod_heat} from "../../utils/consts";

const useStyles = makeStyles({
    table: {
        minWidth: 410,
    },
});

export const Tables = ({rows, title, isComming, isHeat}) => {
    const classes = useStyles();

    const tableHead = () => {
        if (isComming) {
            if (isHeat) {
                return resultRows_prihod_heat.map((item, index) => <TableCell key={index}
                                                                         align={index === 0 ? "left" : 'center'}>{item}</TableCell>)
            }

            return resultRows_prihod.map((item, index) => <TableCell key={index}
                                                                     align={index === 0 ? "left" : 'center'}>{item}</TableCell>)
        } else {
            if (isHeat) {
                return resultRows_rashod_heat.map((item, index) => <TableCell key={index}
                                                                              align={index === 0 ? "left" : 'center'}>{item}</TableCell>)
            }
             return resultRows_rashod.map((item, index) => <TableCell key={index}
                                                              align={index === 0 ? "left" : 'center'}>{item}</TableCell>)
        }
    }

    return (
        <TableContainer component={Paper}>
            <Table className={classes.table} size={'small'} aria-label="simple table">
                <TableHead>
                    <TableRow>
                        {title ? null : tableHead()}
                    </TableRow>
                </TableHead>
                <TableBody>
                    {rows.map((row, index) => (
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
    )
}


