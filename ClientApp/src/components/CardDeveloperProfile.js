import React, { useEffect, useState } from 'react'
import LikeButton from './LikeButton'
import DislikeButton from './DislikeButton'
import Modal from 'react-bootstrap/Modal';

function CardProfile() {

    const [companyInfo, setCompanyInfo] = useState([]);
    const [like, setLike] = useState([]);
    const [currentCompanyIndex, setCurrentCompanyIndex] = useState(0);
    const [recruiterStack, setRecruiterStack] = useState([]);
    const [show, setShow] = useState(false);
    const [currentModalIndex, setCurrentModalIndex] = useState(null);

    const handleClose = () => {
        setShow(false);
        setCurrentModalIndex(null);
    }
    const handleShow = () => setShow(true);

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
    const stackdata = await fetchStacks();
    console.log(data)
    setCompanyInfo(data);
    }

    const handleStacks = async () => {
        const stackdata = await fetchStacks();
        setRecruiterStack(stackdata);
        console.log(stackdata);
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
        
        const likedUsers = currentUser.id;
        
        console.log(currentUser)
        console.log(likedUsers)
        
        let match = likedUsers % 2;
        console.log("teste aqui " + match)
        if(match === 1) {
            alert("it's a match the recruiter will be contacting you soon!");
        }

        /*await fetch(`https://localhost:7033/developer/like/${likedUsers}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json' },
            body: JSON.stringify(currentUser)
        }).then((resp) => resp.json())
            .then((user) => {
                console.log('Success:', user);
            }).catch((err) => {
                console.error('Error:', err);
            });*/

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
                                           return <div className="card mt-30" key={companyInfo.id}>
                                                <div className="frame">
                                                    <img className="imgCard" src={companyInfo.profileImageUrl} alt="user" />
                                                    <p className="username">{companyInfo.companyName}</p> 
                                                    {
                                                        recruiterStack.slice(i, i + 1).map((recruiterStack, j) => {
                                                            return <div className="stackInfo" id={j} key={j}>
                                                                <span>{recruiterStack.stackOne}</span>
                                                                <span>{recruiterStack.stackTwo}</span>
                                                                <span>{recruiterStack.stackThree}</span>
                                                            </div>
                                                        })
                                                    }
                                                </div>
                                                <div className="dsp-flex">
                                                    <DislikeButton dislike={handleDislike} />
                                                    <button className="checkBio" onClick={() => setCurrentModalIndex(i)}>Check Bio</button>
                                                    <Modal show={currentModalIndex === i} onHide={handleClose} >
                                                        <Modal.Header closeButton>
                                                        <Modal.Title>{companyInfo.companyName}</Modal.Title>
                                                        </Modal.Header>
                                                        <Modal.Body>{companyInfo.userbio}</Modal.Body>
                                                        <Modal.Footer>
                                                        <button className="btnCloseModal" onClick={handleClose}>
                                                            Close
                                                        </button>
                                                        </Modal.Footer>
                                                    </Modal>
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
