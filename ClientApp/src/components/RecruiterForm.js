import React from 'react'

function RecruiterForm() {
    return (
        <div className="FormSignUp">
            <h1 className="createAccountTxt">Recruiter, Please fill up the form</h1>
            <div className="container">
                <div className="row">
                    <div className="col-lg-12">
                        <form className="form">
                            <div>
                                <label>Company Name</label>
                            </div>
                            <div>
                                <input type="text" placeholder="Mozart Development Corp." className="form-control"></input>
                            </div>
                            <div>
                                <label>Business Number</label>
                            </div>
                            <div>

                                <input type="text" placeholder="1234143" className="form-control"></input>
                            </div>
                            <div>
                                <label>Email</label>
                            </div>
                            <div>
                                <input type="text" placeholder="John@doe.com" className="form-control"></input>
                            </div>
                            <div>
                                <label>Password</label>
                            </div>
                            <div>
                                <input type="password" className="form-control"></input>
                            </div>
                            <div className="dsp-around mt-10">
                                <input type="submit" value="Register" className="devSubmitForm"></input>
                                <input type="reset" value="Clear" className="clearForm"></input>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default RecruiterForm