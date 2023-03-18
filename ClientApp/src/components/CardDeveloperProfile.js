import React, { useEffect, useState } from 'react'
import LikeButton from './LikeButton'
import DislikeButton from './DislikeButton'

function CardProfile() {

    const [companyInfo, setCompanyInfo] = useState([]);
    const [like, setLike] = useState([]);
    const [currentCompanyIndex, setCurrentCompanyIndex] = useState(0);
    const [recruiterstack, setRecruiterStack] = useState([]);

    const fecthUsers = async () => {
        const resp = await fetch('https://localhost:7033/dashboard/developer');
        const data = await resp.json();
        return data;
    }

    const fetchStacks = async () => {
        const resp = await fetch('https://localhost:7033/recruiterstack');
        const data = await resp.json();
        return data;
    }
    
    const handleRecruitersData = async () => {
    const data = await fecthUsers();
    console.log(data)
    setCompanyInfo(data);
    }

    const handleStacks = async () => {
        const stackdata = await fetchStacks();
        for(let i = 0; i < stackdata.length; i++) {
                setRecruiterStack(stackdata.slice(i, i + 1));
                console.log(stackdata.slice(i,i + 1));
        }
    }

    const handleDislike = async () => {
        const user = await fecthUsers();
        let i = user.findIndex((user) => user.id === companyInfo[currentCompanyIndex].id)
        let currentUser  = user[i];
        user.splice(i, 1);
        handleCardRemove(currentUser.id);
        setCurrentCompanyIndex(currentCompanyIndex + 1)
    }

    const handleLike = async () => {
        const user = await fecthUsers();
        let i = user.findIndex((user) => user.id === companyInfo[currentCompanyIndex].id)
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
        setCurrentCompanyIndex(currentCompanyIndex + 1)
    }

    const handleCardRemove = (userId) => {
        let removedUser = document.querySelector('.card');
        removedUser.remove()
        console.log(`${userId} removed`)
    }
    
    useEffect(() => {
        handleRecruitersData();
        handleStacks();
    }, [])

    return (
        <div>
            <div className="container dsp-flex card-flex">
                <div className="row">
                    <div className="col-lg-12">
                        {
                            companyInfo.length > 0 ? (
                                <div className="cardHolder">
                                    {
                                        companyInfo.map((companyInfo, i) => {
                                           return <div className="card mt-30" key={i}>
                                                <div className="frame">
                                                    <img className="imgCard" src={companyInfo.profileImageUrl} alt="user" />
                                                    <p className="username">{companyInfo.companyName}</p>
                                                        {
                                                            recruiterstack.map((recruiterstack, i) => {
                                                                return <div className="stackInfo" key={i}>
                                                                    <span>{recruiterstack.stackOne}</span>
                                                                    <span>{recruiterstack.stackTwo}</span>
                                                                    <span>{recruiterstack.stackThree}</span>
                                                                </div>
                                                            })
                                                        }
                                                </div>
                                                <div className="dsp-flex">
                                                    <DislikeButton dislike={handleDislike} />
                                                    <button className="checkBio">Check Bio</button>
                                                    <LikeButton like={handleLike}/>
                                                </div>
                                                {/* <div className="username mt-10 dsp-flex-start">
                                                    <p className="username">{companyInfo.companyName}</p>
                                                </div> */}
                                                {/* <div className="bioBox mb-30">
                                                    <p className="username">Stacks:</p>
                                                    {
                                                        recruiterstack.map((recruiterstack, i) => {
                                                            return <ul className="stackInfo" key={i}>
                                                                <li>{recruiterstack.stackOne}</li>
                                                                <li>{recruiterstack.stackTwo}</li>
                                                                <li>{recruiterstack.stackThree}</li>
                                                            </ul>
                                                        })
                                                    }
                                                </div> */}
                                                    {/* <p className="username">{companyInfo.userbio}</p> */}
                                                {/* <div className="dsp-flex">
                                                    <DislikeButton dislike={handleDislike} />
                                                    <LikeButton like={handleLike}/>
                                                </div> */}
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
