import React from 'react'
import { Link } from 'react-router-dom';
import CardDevProfile from '../components/CardDeveloperProfile'
import EditButton from './editButton';
import Footer from './Footer'


function DashboardDeveloper() {

    const name = sessionStorage.getItem('name');
    const user = JSON.parse(name)

    for(const item of user.result) {
        if(item.type === 'CompanyName') {
            console.log(item.value);
        }
    }

    return (
        <div className="container">
            <div className="row">
                <div className="col-lg-12">
                    <div className="dsp-flex mt-30 mb-30">
                        <Link to="/edit">
                            <EditButton />
                        </Link>
                    </div>
                    <CardDevProfile />
                </div>
            </div>
            <Footer />
        </div>
    )
}

export default DashboardDeveloper