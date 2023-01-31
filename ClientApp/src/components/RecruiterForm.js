import React, { useState } from 'react'

function RecruiterForm() {
    const [companyName, setCompanyName] = useState('');
    const [businessNumber, setBusinessNumber] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const handleSubmit = async() => {
        const user = {
            companyName,
            businessNumber,
            email,
            password
        };

        await fetch('https://localhost:7033/recruiter', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'    
            },
            body: JSON.stringify(user)
        }).then((resp) => {
            return resp.json()
        }).then((err) => {
            console.log(err)
        })
    }

    return (
        <div className="FormSignUp">
            <h1 className="createAccountTxt">Recruiter, Please fill up the form</h1>
            <div className="container">
                <div className="row">
                    <div className="col-lg-12">
                        <form className="form" onSubmit={handleSubmit}>
                            <div>
                                <label>Company Name</label>
                            </div>
                            <div>
                                <input type="text" placeholder="Mozart Development Corp." className="form-control" value={companyName} onChange={(e) => setCompanyName(e.target.value)} />
                            </div>
                            <div>
                                <label>Business Number</label>
                            </div>
                            <div>
                                <input type="text" placeholder="1234143" className="form-control" value={businessNumber} onChange={(e) => setBusinessNumber(e.target.value)} />
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
                                <input type="password" className="form-control" value={password} onChange={(e) => setPassword(e.target.value)}></input>
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

export default RecruiterForm