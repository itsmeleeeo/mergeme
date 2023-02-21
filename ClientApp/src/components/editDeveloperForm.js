import React, { useEffect, useState } from "react";
import { useNavigate } from 'react-router-dom';

function EditProfile() {
    const [stackData, setStackData] = useState({});
    const [firstName, setFirstname] = useState('');
    const [lastName, setLastName] = useState('');
    const [position, setPosition] = useState('');
    const [stackOne, setStackOne] = useState('');
    const [stackTwo, setStackTwo] = useState('');
    const [stackThree, setStackThree] = useState('');
    const [userbio, setUserbio] = useState('');
    const [profileImage, setProfileImage] = useState('');
    const nav = useNavigate();

    useEffect(() => {
        handleStackData();
    }, [])

    const handleStackData = async () => {
        const resp = await fetch('https://localhost:7033/stack')
        const data = await resp.json()
        setStackData(data);
        console.log(data)
        return data
    }

    const handleStackChoice = (e) => {
        console.log(e.target.value)
    }

    const handleSubmit = async (e) => {
        e.preventDefault();
        const user = {
            firstName,
            lastName,
            position,
            stackOne,
            stackTwo,
            stackThree,
            userbio
        };

        await fetch('https://localhost:7033/developer/{id}', {
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
                alert(`Something went wrong ${err}`)
                console.error('Error:', err);
            });
    }

    return(
        <div>
            <div className="container">
                <div className="row">
                    <div className="col-lg-12">
                        <form onSubmit={handleSubmit}>
                            <div>
                                <label for="exampleInputEmail1" class="form-label">Enter your first name</label>
                                <input type="text" placeholder="John" className="form-control" value={firstName} onChange={(e) => setFirstname(e.target.value)} required />
                            </div>
                            <div>
                                <label for="exampleInputEmail1" class="form-label">Enter your last name</label>
                                <input type="text" placeholder="Doe" className="form-control" value={lastName} onChange={(e) => setLastName(e.target.value)} required />
                            </div>
                            <div>
                                <label for="exampleInputEmail1" class="form-label">Enter your position</label>
                                <input type="text" placeholder="eg.Full-Stack Developer" className="form-control" value={position} onChange={(e) => setPosition(e.target.value)} required />
                            </div>
                            <div>
                                <label for="exampleInputEmail1" class="form-label">Select your first option</label>
                                <div id="emailHelp" class="form-text">Choose the first language in which you are most proficient and it will be your profile picture</div>
                                <select onChange={handleStackChoice} class="form-select" aria-label="Default select example">
                                    {stackData && stackData.length > 0 && stackData.map((stack, i) => (
                                        <option key={stack.id} value={stack.stackName} >{stack.stackName}</option>
                                    ))}
                                </select>
                            </div>
                            <div>
                                <label for="exampleInputEmail1" class="form-label">Select your second option</label>
                                <select onChange={handleStackChoice} class="form-select" aria-label="Default select example">
                                    {stackData && stackData.length > 0 && stackData.map((stack, i) => (
                                        <option key={stack.id} value={stack.stackName}>{stack.stackName}</option>
                                    ))}
                                </select>
                            </div>
                            <div>
                                <label for="exampleInputEmail1" class="form-label">Select your third option</label>
                                <select onChange={handleStackChoice} class="form-select" aria-label="Default select example">
                                    {stackData && stackData.length > 0 && stackData.map((stack, i) => (
                                        <option key={stack.id} value={stack.stackName}>{stack.stackName}</option>
                                    ))}
                                </select>
                            </div>
                            <div>
                                <label for="exampleInputEmail1" class="form-label">Type your bio</label>
                                <textarea class="form-control" placeholder="Leave a comment here" value={userbio} onChange={(e) => setUserbio(e.target.value)}></textarea>
                            </div>
                            <div className="dsp-around mt-10 mb-30">
                                <input type="submit" value="Update" className="devSubmitForm" />
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