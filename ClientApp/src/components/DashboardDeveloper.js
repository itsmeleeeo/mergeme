import React from 'react'
import CardProfile from '../components/CardProfile'
import Footer from './Footer'

function DashboardDeveloper() {

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