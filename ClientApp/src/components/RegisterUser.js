import React, { useState } from 'react'
import { Link } from 'react-router-dom';
import FormDeveloper from './DeveloperForm'
import FormRecruiter from './RecruiterForm'
import '../../src/custom.css'

function Developer() {
    const [hidden, setHidden] = useState(true)
    return (
        <div>
            <div className="dsp-flex mt-80 mb-30">
                <button className="userForm" onClick={() => setHidden(s => !s)}>Developer</button>
                <button className="userForm" onClick={() => setHidden(x => !x)}>Recruiter</button>
            </div>
            <div>
                {hidden ? <FormDeveloper /> : <FormRecruiter />}
            </div>
        </div>
    )
}

export default Developer