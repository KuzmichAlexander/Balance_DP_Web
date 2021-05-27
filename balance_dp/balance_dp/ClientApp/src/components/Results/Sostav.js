import React from 'react';
import Paper from "@material-ui/core/Paper";
import Table from "@material-ui/core/Table";
import TableHead from "@material-ui/core/TableHead";
import TableRow from "@material-ui/core/TableRow";
import TableCell from "@material-ui/core/TableCell";
import TableBody from "@material-ui/core/TableBody";
import TableContainer from "@material-ui/core/TableContainer";
import {makeStyles} from "@material-ui/core/styles";
import {sostavDescription} from "../../utils/materialBalance";

const useStyles = makeStyles({
    table: {
        minWidth: 410,
    },
});

export const Sostav = ({result}) => {
    const classes = useStyles();

    return (
        <>
            <h1 className={'title-sostav'}>Средневзвешенный состав рудного материала, %</h1>
            <TableContainer component={Paper}>
                <Table className={classes.table} size={'small'} aria-label="simple table">
                    <TableHead>
                        <TableRow>
                            {sostavDescription.map((item, index) => <TableCell key={index}
                                                                               align={"left"}>{item}</TableCell>)}
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        <TableRow>
                            <TableCell component="th" scope="row">
                                {result.A8_Fe}
                            </TableCell>
                            <TableCell component="th" scope="row">
                                {result.B8_FeO}
                            </TableCell>
                            <TableCell component="th" scope="row">
                                {result.C8_Fe2O3}
                            </TableCell>
                            <TableCell component="th" scope="row">
                                {result.D8_SiO2}
                            </TableCell>
                            <TableCell component="th" scope="row">
                                {result.E8_AlO3}
                            </TableCell>
                            <TableCell component="th" scope="row">
                                {result.F8_CaO}
                            </TableCell>
                            <TableCell component="th" scope="row">
                                {result.G8_MgO}
                            </TableCell>
                            <TableCell component="th" scope="row">
                                {result.H8_P}
                            </TableCell>
                            <TableCell component="th" scope="row">
                                {result.I8_S}
                            </TableCell>
                            <TableCell component="th" scope="row">
                                {result.J8_MnO}
                            </TableCell>
                            <TableCell component="th" scope="row">
                                {result.J8_MnO}
                            </TableCell>
                            <TableCell component="th" scope="row">
                                {result.L8_Pmpp}
                            </TableCell>
                            <TableCell component="th" scope="row">
                                {result.M8_H20}
                            </TableCell>
                            <TableCell component="th" scope="row">
                                {result.N8_TiO2}
                            </TableCell>
                            <TableCell component="th" scope="row">
                                {result.O8_Cr}
                            </TableCell>
                        </TableRow>
                    </TableBody>
                </Table>
            </TableContainer>
        </>
    );
};
