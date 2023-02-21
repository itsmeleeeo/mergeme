import React, { useEffect, useState } from 'react'
import LikeButton from './LikeButton'
import DislikeButton from './DislikeButton'

function CardProfile(match) {

    const [companyInfo, setCompanyInfo] = useState([]);
    const [dislike, setDislike] = useState([]);
    
    const handleRecruitersData = async () => {
    const resp = await fetch('https://localhost:7033/dashboard/developer');
    const data = await resp.json();
    console.log(data)
    setCompanyInfo(data);
}
    
    useEffect(() => {
        handleRecruitersData();
    }, [])

    const handleDislike = async (id) => {
        const resp = await fetch('https://localhost:7033/dashboard/developer');
        const data = resp.json();
        dislike = data;
        setDislike(dislike.filter(companyInfo => companyInfo.id !== id))

    }

    return (
        <div>
            <div className="container dsp-flex card-flex">
                <div className="row">
                    <div className="col-lg-12">
                        {
                            companyInfo.length > 0 ? (
                                <div>
                                    {
                                        companyInfo.map(companyInfo => {
                                           return <div className="card mt-30" key={companyInfo.id}>
                                                <div className="frame">
                                                    <img className="imgCard" src={companyInfo.profileImageUrl} alt="user" />
                                                </div>
                                                <div className="username mt-10 dsp-flex-start">
                                                    <p className="username">{companyInfo.companyName}</p>
                                                </div>
                                                <div className="bioBox mb-30">
                                                    <p className="username">Stacks:</p>
                                                    <ul className="stackInfo">
                                                        <li>stackOne</li>
                                                        <li>stackTwo</li>
                                                        <li>stackThree</li>
                                                    </ul>
                                                    <p className="username">{companyInfo.userbio}</p>
                                                </div>
                                                <div className="dsp-flex">
                                                    <DislikeButton />
                                                    <LikeButton />
                                                </div>
                                            </div>
                                        })
                                    }
                                    
                                </div>
                            ) : (<div className="empty">No more swipes for today :/</div>)
                        }
                    </div>
                </div>
            </div>
        </div>
    )
}

export default CardProfile
