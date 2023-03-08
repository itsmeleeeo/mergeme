import React, { useEffect, useState } from 'react'
import LikeButton from './LikeButton'
import DislikeButton from './DislikeButton'

function CardProfile() {

    const fecthUsers = async () => {
        const resp = await fetch('https://localhost:7033/dashboard/developer');
        const data = await resp.json();
        return data;
    }
    
    const handleRecruitersData = async () => {
    const data = await fecthUsers();
    console.log(data)
    setCompanyInfo(data);
}

    const handleDislike = async () => {
        const user = await fecthUsers();
        let i = user.findIndex((user) => user.id === currentUserId)
        let currentUser  = user[i];
        user.splice(currentUser);
        handleCardRemove(currentUser.id);
    }

    const handleLike = async () => {
        const user = await fecthUsers();
        let i = user.findIndex((user) => user.id === currentUserId)
        let currentUser  = user[i];
        let nextUser = user[i + 1];

        if(nextUser) {
            const waitForLike = like.includes(nextUser.id);
            
            if(waitForLike) {
                console.log(`A company is interested on you`)
            }
        }

        user.push(currentUser);
        setLike((previousLike) => [...previousLike, currentUser.id])
        console.log(currentUser)
        handleCardRemove(currentUser.id);
    }

    const handleCardRemove = (userId) => {
        let removedUser = document.querySelector('.card');
        removedUser.remove()
        console.log(`${userId} removed`)
    }

    const [companyInfo, setCompanyInfo] = useState([]);
    const [like, setLike] = useState([]);
    const currentUserId = companyInfo.length > 0 ? companyInfo[0].id : null
    
    useEffect(() => {
        handleRecruitersData();
    }, [])

    return (
        <div>
            <div className="container dsp-flex card-flex">
                <div className="row">
                    <div className="col-lg-12">
                        {
                            companyInfo.length > 0 ? (
                                <div>
                                    {
                                        companyInfo.map((companyInfo, i) => {
                                           return <div className="card mt-30" key={i}>
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
                                                    <DislikeButton dislike={handleDislike} />
                                                    <LikeButton like={handleLike}/>
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
