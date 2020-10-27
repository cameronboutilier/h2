import React, { useState } from 'react';
import ItemListView from './ItemListView';
import './ItemList.css';
import api from '../Api.js';

function ItemList()  {
    const [iList, setItemList] = useState([]);
    const [hpList, setHPList] = useState([]);
    const [cDate, setCDate] = useState(new Date());
    const [loaded, setLoaded] = useState(false);

    // If not loaded get all items in list from backend.
    if (!loaded)
    {
        api.loadItems(cDate).then(
            (res) => {
                setItemList(res.data);
                var hp = 0;
                var hpl = []
                res.data.forEach(h => {
                    if (h.profit > hp)
                    {
                        hp = h.profit;
                        hpl = [];
                        hpl.push(h);
                    }
                    else if (h.profit === hp)
                    {
                        hpl.push(h);
                    }
                });
                setHPList(hpl);
                setLoaded(true);
            },(error) => {
                setItemList([]);
                setLoaded(true);
            }
        );
    }

    const changeDate = (date) => {
        setCDate(date);
        setLoaded(false);
    }

    //Show loading text while loading.
    if (loaded)
        return(<>
            <ItemListView iList={iList} hpList={hpList} selectDate={changeDate} selectedDate={cDate} />
        </>);
    else 
        return(
            <>
                Loading...
            </>
        )
  
};
 
export default ItemList;