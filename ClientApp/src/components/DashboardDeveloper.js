import React, {useState} from 'react'
import { Link } from 'react-router-dom';
import CardProfile from '../components/CardProfile'
import EditButton from './editButton';
import Footer from './Footer'

function DashboardDeveloper() {

    const [username, setUsername] = useState();
    const [userImage, setImage] = useState();
    const [userPosition, setPosition] = useState();
    const [userStack, setUserStack] = useState();
    const [userbio, setUserBio] = useState();

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

export default DashboardDeveloper