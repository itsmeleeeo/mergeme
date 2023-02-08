import React, { useState } from 'react'
import { useNavigate } from 'react-router-dom'
import Footer from './Footer'

function Login() {

    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const navigate = useNavigate();

    const handleLogin = async (e) => {
        e.preventDefault();
        const user = {
            email,
            password
        };
        await fetch('https://localhost:7033/login', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        }).then((response) => response.json())
            .then((data) => {
                console.log('success: ', data)
                navigate('/dashboard/developer')
            })
            .catch((err) => {
                console.error('error: ', err);
            });
    }
    return (
        <div className="container">
            <div className="row">
                <div className="col-lg-12">
                    <div className="FormSignUp">
                        <form className="form" onSubmit={handleLogin}>
                            <div>
                                <label>Email</label>
                            </div>
                            <div>
                                <input type="email" placeholder="John@doe.com" className="form-control" value={email} onChange={(e) => setEmail(e.target.value)} />
                            </div>
                            <div>
                                <label>Password</label>
                            </div>
                            <div>
                                <input type="password" className="form-control" value={password} onChange={(e) => setPassword(e.target.value)} />
                            </div>
                            <div className="dsp-around mt-10 mb-30">
                                <input type="submit" value="Login" className="devSubmitForm"></input>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
            <Footer />
        </div>
    )
}

export default Login