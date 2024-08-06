import React, { Fragment,useState } from 'react';
import axios from 'axios';

function Registration()
{
    const [name,setName]=useState('');
    const [phoneNo,setPhoneNo]=useState('');
    const [Address,setAddress]=useState('');

    const handleNameChange=(value)=>
    {
        setName(value);
    };
    const handlePhoneNoChange=(value)=>
        {
            setPhoneNo(value);
        };
        const handleAddressChange=(value)=>
            {
                setAddress(value);
            };

            const handleSave =() =>{
                const data={
                    Name:name,
                    PhoneNo :phoneNo,
                    Address:Address,
                    isActive:1
                };
                const url='https://localhost:44385//api/Test/Registration';
                axios.post(url,data).then((result)=>{
                    // if(result.data=='Data inserted.')
                    //     alert('data saved');
                    // else
                    alert(result.data);
                }).catch((error)=>{
                    alert(error);
                })
            }

    return(
        <Fragment>
            <div>Registration</div>
            <label>Name</label>
            <input type='text' id='txtName' placeholder='Enter Name ' onChange={(e)=>handleNameChange(e.target.value)}/> <br></br>
            <label>Phone NO</label>
            <input type='text' id='txtPhone' placeholder='Enter Phone '  onChange={(e)=>handlePhoneNoChange(e.target.value)}/> <br></br>
            <label>Address</label>
            <input type='text' id='txtAddress' placeholder='Enter Address '  onChange={(e)=>handleAddressChange(e.target.value)}/> <br></br>
            <button onClick={()=>handleSave()}>Save</button>
        </Fragment>
        
    )
}

export default Registration;