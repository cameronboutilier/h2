import React from 'react';
import Table from 'react-bootstrap/Table';
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";

function ItemListView({ iList, hpList, selectDate, selectedDate }){
    return(
        <>
            <link href="ItemList.css" rel="stylesheet" type="text/css" />
            <Table>
                <th>
                    All Cars
                </th>
                <th/>
                <th/>
            <tbody>
                {iList.map((car) => (
                    <>
                <tr>
                    <td>
                        {car.type + (car.convertible ? " (Convertible)" : "")}
                    </td>
                    <td>
                        {car.color}
                    </td>
                    <td>
                        ${car.price.toFixed(2)}
                    </td>
                </tr>
                    
                </>
            ))}
                <th>
                    Best Profit
                </th>
                <th/>
                <th/>
                {hpList.map((car) => (
                    <>
                <tr>
                    <td>
                        {car.type + (car.convertible ? " (Convertible)" : "")}
                    </td>
                    <td>
                        {car.color}
                    </td>
                    <td>
                        ${car.price.toFixed(2)}
                    </td>
                </tr>
                    
                </>
                ))}
            </tbody>
            </Table>
            <DatePicker selected={selectedDate} onChange={date => selectDate(date)} />
            
        </>
        );
};

export default ItemListView;