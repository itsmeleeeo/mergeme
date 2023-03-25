import React, { useEffect, useState } from "react";
import { useNavigate } from 'react-router-dom';

function EditProfile() {
    const id = sessionStorage.getItem('Id');
    const name = sessionStorage.getItem('name');

    const [stackData, setStackData] = useState({});
    const [firstName, setFirstname] = useState('');
    const [lastName, setLastName] = useState('');
    const [position, setPosition] = useState('');
    const [stackOne, setStackOne] = useState('');
    const [stackTwo, setStackTwo] = useState('');
    const [stackThree, setStackThree] = useState('');
    const [userbio, setUserbio] = useState('');
    const [profileImage, setProfileImage] = useState(''); 
    const [routeId, setRouteId] = useState('');
    const nav = useNavigate();

    useEffect(() => {
        let userName = JSON.parse(name)

        for(const item of userName.result) {
            if(item.type === 'FirstName') {
                setFirstname(item.value);
            }else if(item.type === 'LastName') {
                setLastName(item.value);
                break;
            } else if(item.type === 'status') {
                console.log(item.value)
                setRouteId(item.value)
                break;
            }
        }
        handleStackData();
    }, [])

    const handleStackData = async () => {
        const resp = await fetch('https://localhost:7033/stack')
        const data = await resp.json()
        setStackData(data);
        console.log(data)
        return data
    }

    const handleSubmit = async (e, routeId) => {
        e.preventDefault();
        const firstName = "";
        const lastName = "";
        const position = "";
        const stackOne = "";
        const stackTwo = "";
        const stackThree = "";
        const userbio = "";
        const user = {
            firstName,
            lastName,
            position,
            stackOne,
            stackTwo,
            stackThree,
            userbio
        };

        await fetch(`https://localhost:7033/developer/${id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        }).then((resp) => resp.json())
            .then((user) => {
                console.log('Success:', user);
                nav('/')
            }).catch((err) => {
                console.warn(`Something went wrong ${err}`)
                console.warn('quebrou')
                console.error('Error:', err);
            });
    }

    return(
        <div>
            <div className="container">
                <div className="row">
                    <div className="col-lg-12">
                        <form>
                            <div>
                                <label className="form-label">Enter your first name</label>
                                <input type="text" className="form-control" value={firstName} readOnly />
                            </div>
                            <div>
                                <label className="form-label">Enter your last name</label>
                                <input type="text" className="form-control" value={lastName} readOnly />
                            </div>
                            <div>
                                <label className="form-label">Enter your position</label>
                                <input type="text" placeholder="eg.Full-Stack Developer" className="form-control" value={position} onChange={(e) => setPosition(e.target.value)} required />
                            </div>
                            <div>
                                <label className="form-label">Select your first option</label>
                                <div id="emailHelp" className="form-text">Choose the first language in which you are most proficient and it will be your profile picture</div>
                                <select onChange={(e) => setStackOne(e.target.value)} className="form-select" aria-label="Default select example">
                                    {stackData && stackData.length > 0 && stackData.map((stack, i) => (
                                        <option key={i} value={stack.stackName}>{stack.stackName}</option>
                                    ))}
                                </select>
                            </div>
                            <div>
                                <label className="form-label">Select your second option</label>
                                <select onChange={(e) => setStackTwo(e.target.value)} className="form-select" aria-label="Default select example">
                                    {stackData && stackData.length > 0 && stackData.map((stack, i) => (
                                        <option key={i} value={stack.stackName}>{stack.stackName}</option>
                                    ))}
                                </select>
                            </div>
                            <div>
                                <label className="form-label">Select your third option</label>
                                <select onChange={(e) => setStackThree(e.target.value)} className="form-select" aria-label="Default select example">
                                    {stackData && stackData.length > 0 && stackData.map((stack, i) => (
                                        <option key={i} value={stack.stackName}>{stack.stackName}</option>
                                    ))}
                                </select>
                            </div>
                            <div>
                                <label className="form-label">Type your bio</label>
                                <textarea className="form-control" placeholder="Leave a comment here" value={userbio} onChange={(e) => setUserbio(e.target.value)}></textarea>
                            </div>
                            <div className="dsp-around mt-10 mb-30">
                                <input type="submit" value="Update" className="devSubmitForm" onClick={(e) => handleSubmit(e, id)}/>
                                <input type="reset" value="Clear" className="clearForm" />
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default EditProfile;