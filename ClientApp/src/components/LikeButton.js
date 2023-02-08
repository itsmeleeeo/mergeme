import React from 'react'
import Like from '../images/heart.png'

function LikeButton(props) {
    return(
        <div>
            <button className="likeButton mt-30" onClick={props.like}>
                <img className="likeImg" src={Like} alt="like button" />
            </button>
        </div>
    )
}

export default LikeButton;