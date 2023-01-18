import React from 'react'
import { Link } from 'react-router-dom';
import FormDeveloper from './Form'
import '../../src/custom.css'

function Developer() {
    return (
        <div>
            <h1 className="createAccountTxt">Fill up the form</h1>
            <div>
                <FormDeveloper />
            </div>
        </div>
    )
}

export default Developer