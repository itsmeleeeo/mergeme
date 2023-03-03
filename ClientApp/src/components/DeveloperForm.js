import React, { useState } from 'react'
import { useNavigate } from 'react-router-dom';
import Footer from './Footer'

function DeveloperForm() {

    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const nav = useNavigate();

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
                'Content-Type': 'application/json' },
            body: JSON.stringify(user)
        }).then((resp) => resp.json())
            .then((user) => {
                console.log('Success:', user);
                nav('/login')
            }).catch((err) => {
                alert(`Something went wrong ${err}`)
                console.error('Error:', err);
            });
    }

    return (
        <div className="container">
            <div className="row">
                <div className="col-lg-12">
                    <div className="FormSignUp">
                        <h1 className="createAccountTxt">Developer, Please fill up the form</h1>
                        <form className="form" onSubmit={handleSubmit}>
                            <div>
                                <label>First Name</label>
                            </div>
                            <div>
                                <input type="text" placeholder="John" className="form-control" value={firstName} onChange={(e) => setFirstName(e.target.value)} required />
                            </div>
                            <div>
                                <label>Last Name</label>
                            </div>
                            <div>
                                <input type="text" placeholder="Doe" className="form-control" value={lastName} onChange={(e) => setLastName(e.target.value)} required />
                            </div>
                            <div>
                                <label>Email</label>
                            </div>
                            <div>
                                <input type="email" placeholder="John@doe.com" className="form-control" value={email} onChange={(e) => setEmail(e.target.value)} required />
                            </div>
                            <div>
                                <label>Password</label>
                            </div>
                            <div>
                                <input type="password" className="form-control" value={password} onChange={(e) => setPassword(e.target.value)} required />
                            </div>
                            <div className="dsp-around mt-10 mb-30">
                                <input type="submit" value="Register" className="devSubmitForm" />
                                <input type="reset" value="Clear" className="clearForm" />
                            </div>
                        </form>
                    </div>
                </div>
            </div>
            <Footer />
        </div>
    )
}

export default DeveloperForm