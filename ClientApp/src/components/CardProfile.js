import React from 'react'

function CardProfile(props) {

    return (
        <div className="container">
            <div className="row">
                <div className="col-lg-12">
                    <div className="card dsp-flex">
                        <img className="imgCard mt-30" src={props.userProfile} alt="user image" />
                        <div className="username mt-10 dsp-flex-start">
                            <p>{props.firstName}</p>
                            <p className="ml-5 mr-5">-</p>
                            <p>{props.position}</p>
                        </div>
                        <div className="bioBox mb-30">
                            <p className="username">Main Stacks:</p>
                            <ul className="stackInfo">
                                <li>{props.stackOne}</li>
                                <li>{props.stackTwo}</li>
                                <li>{props.stackThree}</li>
                            </ul>
                            <p className="username">{props.userbio}</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default CardProfile