import React, {useState} from 'react'
import CardProfile from '../components/CardProfile'
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
                    <CardProfile />
                </div>
            </div>
            <Footer />
        </div>
    )
}

export default DashboardDeveloper