import React, { useState } from 'react'
import { Button } from 'react-bootstrap'

const axios = require('axios')

const Item = ({item}) => { 
    const [isCompleted, setCompleted] = useState(item.isCompleted)

    async function handleMarkAsComplete(item) {
        item.isCompleted = true;

        axios.put('https://localhost:44397/api/todoitems/' + item.id, item)
        .then(response => {
            setCompleted(true); 
        });
    }

    return (
        <tr>
            <td>{item.id}</td>
            <td>{item.description}</td>
            <td>
                <Button disabled={isCompleted} variant="warning" size="sm" onClick={() => handleMarkAsComplete(item)}>{isCompleted ? 'Completed' : 'Mark as completed'}</Button>
            </td>
        </tr>
    )
}

export default Item