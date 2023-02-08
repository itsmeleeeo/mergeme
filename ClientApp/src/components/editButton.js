import React from "react";
import Edit from '../images/edit.png'

function EditButton() {
    return(
        <div>
            <button className="likeButton">
                <img className="likeImg" src={Edit} alt="edit button" />
            </button>
        </div>
    )
}

export default EditButton