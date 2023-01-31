import React from 'react'

function RegisterButton(props) {
    return (
        <div>
            <button className={props.registerstyle}>{props.register}</button>
        </div>
        )
}

export default RegisterButton