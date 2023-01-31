import React, { useState } from 'react'

function DeveloperForm() {

    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const handleSubmit = async () => {
        const user = {
            firstName,
            lastName,
            email,
            password
        };
        await fetch('https://localhost:7033/developer', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json' },
            body: JSON.stringify(user)
        }).then((resp) => {
            return resp.json()
        }).then((err) => {
            console.log(err);
        });
    }

    return (
        <div className="FormSignUp">
            <h1 className="createAccountTxt">Developer, Please fill up the form</h1>
            <div className="container">
                <div className="row">
                    <div className="col-lg-12">
                        <form className="form" onSubmit={handleSubmit}>
                            <div>
                                <label>First Name</label>
                            </div>
                            <div>
                                <input type="text" placeholder="John" className="form-control" value={firstName} onChange={(e) => setFirstName(e.target.value)} />
                            </div>
                            <div>
                                <label>Last Name</label>
                            </div>
                            <div>
                                <input type="text" placeholder="Doe" className="form-control" value={lastName} onChange={(e) => setLastName(e.target.value)} />
                            </div>
                            <div>
                                <label>Email</label>
                            </div>
                            <div>
                                <input type="text" placeholder="John@doe.com" className="form-control" value={email} onChange={(e) => setEmail(e.target.value)} />
                            </div>
                            <div>
                                <label>Password</label>
                            </div>
                            <div>
                                <input type="password" className="form-control" value={password} onChange={(e) => setPassword(e.target.value)} />
                            </div>
                            <div className="dsp-around mt-10">
                                <input type="submit" value="Register" className="devSubmitForm"></input>
                                <input type="reset" value="Clear" className="clearForm"></input>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default DeveloperForm