import React from 'react'
import { Link } from 'react-router-dom';
import CardProfile from '../components/CardDeveloperProfile'
import EditButton from './editButton';
import Footer from './Footer'

function Login() {

    return (
        <div className="container">
            <div className="row">
                <div className="col-lg-12">
                    <div className="dsp-flex mt-30 mb-30">
                        <Link to="/edit">
                            <EditButton />
                        </Link>
                    </div>
                    <CardProfile />
                </div>
            </div>
            <Footer />
        </div>
    )
}

export default Login