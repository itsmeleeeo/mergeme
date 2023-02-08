import React from 'react'
import LikeButton from './LikeButton'
import DislikeButton from './DislikeButton'

function CardProfile(props) {

    return (
        <div>
            <div className="container dsp-flex card-flex">
                <div className="row">
                    <div className="col-lg-12">
                        <div className="card">
                            <img className="imgCard mt-30" src={props.userProfile} alt={props.altImage} />
                            <div className="username mt-10 dsp-flex-start">
                                <p>{props.firstName}</p>
                                <p className="ml-5 mr-5">-</p>
                                <p>{props.position}</p>
                            </div>
                            <div className="bioBox mb-30">
                                <p className="username">Main Stacks:</p>
                                <ul className="stackInfo">
                                    <li>{props.stack}</li>
                                </ul>
                                <p className="username">{props.userbio}</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div className="dsp-flex">
            <DislikeButton />
            <LikeButton />
            </div>
        </div>
    )
}

export default CardProfile