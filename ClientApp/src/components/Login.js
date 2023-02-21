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
                'Content-Type': 'application/json' },
            body: JSON.stringify(user)
        }).then((resp) => resp.json())
            .then((user) => {
                console.log('Success:', user);
                navigate('/dashboard/developer')
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
                                <button type="submit" className="devSubmitForm">Login</button>
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