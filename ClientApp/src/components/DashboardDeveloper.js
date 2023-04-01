import React, { useEffect, useState } from 'react'
import { Link } from 'react-router-dom';
import CardDevProfile from '../components/CardDeveloperProfile'
import CardRecProfile from './CardRecruiterProfile';
import EditButton from './editButton';
import Footer from './Footer'


function DashboardDeveloper() {
    
    const [acctype , setAccType] = useState('');
    useEffect(() => {
        const name = sessionStorage.getItem('name');
        const user = JSON.parse(name)

        for(const item of user.result) {
            if(item.type === 'CompanyName') {
                setAccType(item.type);
            }
        }
    }, []);

    return (
        <div className="container">
            <div className="row">
                <div className="col-lg-12">
                    <div className="dsp-flex mt-30 mb-30">
                    {
                        (acctype === 'CompanyName') ? (<Link to="/editrec"><EditButton /></Link>) : (<Link to="/editdev"><EditButton /></Link>)
                    }
                    </div>
                    {
                        (acctype === 'CompanyName') ? (<CardRecProfile />) : (<CardDevProfile />)
                    }
                </div>
            </div>
            <Footer />
        </div>
    )
}

export default DashboardDeveloper