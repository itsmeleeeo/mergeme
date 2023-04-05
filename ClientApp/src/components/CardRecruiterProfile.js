import React, { useEffect, useState } from 'react'
import LikeButton from './LikeButton'
import DislikeButton from './DislikeButton'
import Modal from 'react-bootstrap/Modal';

function CardProfile() {

    const [developerInfo, setdeveloperInfo] = useState([]);
    const [like, setLike] = useState([]);
    const [currentDeveloperIndex, setcurrentDeveloperIndex] = useState(0);
    const [developerStack, setdeveloperStack] = useState([]);
    const [show, setShow] = useState(false);
    const [currentModalIndex, setCurrentModalIndex] = useState(null);

    const handleClose = () => {
        setShow(false);
        setCurrentModalIndex(null);
    }
    const handleShow = () => setShow(true);

    const fecthUsers = async () => {
        const resp = await fetch('https://localhost:7033/dashboard/recruiter');
        const data = await resp.json();
        return data;
    }

    const fetchStacks = async () => {
        const resp = await fetch('https://localhost:7033/developerstack');
        const data = await resp.json();
        return data;
    }
    
    const handleDevelopersData = async () => {
    const data = await fecthUsers();
    const stackdata = await fetchStacks();
    console.log(data)
    setdeveloperInfo(data);
    }

    const handleStacks = async () => {
        const stackdata = await fetchStacks();
        setdeveloperStack(stackdata);
        console.log(stackdata);
    }

    const handleDislike = async () => {
        const user = await fecthUsers();
        let i = user.findIndex((user) => user.id === developerInfo[currentDeveloperIndex].id)
        let currentUser  = user[i];
        user.splice(i, 1);
        handleCardRemove(currentUser.id);
        setcurrentDeveloperIndex(currentDeveloperIndex + 1)
    }

    const handleLike = async () => {
        const user = await fecthUsers();
        let i = user.findIndex((user) => user.id === developerInfo[currentDeveloperIndex].id)
        let currentUser  = user[i];
        let nextUser = user[i + 1];

        if(nextUser) {
            const waitForLike = like.includes(nextUser.id);
            
            if(waitForLike) {
                console.log(`A Developer is interested on you`)
            }
        }

        user.push(currentUser);
        setLike((previousLike) => [...previousLike, currentUser.id])
        console.log(currentUser)
        handleCardRemove(currentUser.id);
        setcurrentDeveloperIndex(currentDeveloperIndex + 1)
    }

    const handleCardRemove = (userId) => {
        let removedUser = document.querySelector('.card');
        removedUser.remove()
        console.log(`${userId} removed`)
    }
    
    useEffect(() => {
        handleDevelopersData();
        handleStacks();
    }, [])

    return (
        <div>
            <div className="container dsp-flex card-flex">
                <div className="row">
                    <div className="col-lg-12">
                        {
                            developerInfo.length > 0 ? (
                                <div className="cardHolder">
                                    {
                                        developerInfo.map((developerInfo, i) => {
                                           return <div className="card mt-30" key={developerInfo.id}>
                                                <div className="frame">
                                                    <img className="imgCard" src={developerInfo.profileImageUrl} alt="user" />
                                                    <p className="username">{developerInfo.firstName + " " + developerInfo.lastName}</p> 
                                                    {
                                                        developerStack.slice(i, i + 1).map((developerStack, j) => {
                                                            return <div className="stackInfo" id={j} key={j}>
                                                                <span>{developerStack.stackOne}</span>
                                                                <span>{developerStack.stackTwo}</span>
                                                                <span>{developerStack.stackThree}</span>
                                                            </div>
                                                        })
                                                    }
                                                </div>
                                                <div className="dsp-flex">
                                                    <DislikeButton dislike={handleDislike} />
                                                    <button className="checkBio" onClick={() => setCurrentModalIndex(i)}>Check Bio</button>
                                                    <Modal show={currentModalIndex === i} onHide={handleClose} >
                                                        <Modal.Header closeButton>
                                                        <Modal.Title>{developerInfo.firstName + " " + developerInfo.lastName}</Modal.Title>
                                                        </Modal.Header>
                                                        <Modal.Body>{developerInfo.userBio}</Modal.Body>
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
