import React from 'react'
import Dislike from '../images/delete.png'

function DislikeButton(props) {
    return(
        <div>
            <button className="likeButton" onClick={props.dislike}>
                <img className="likeImg" src={Dislike} alt="like button" />
            </button>
        </div>
    )
}

export default DislikeButton;