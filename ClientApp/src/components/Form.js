import React, { Component } from 'react'

class Form extends Component {
    constructor(props) {
        super(props);
        this.state = { value: '' };

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleChange(e) {
        this.setState({ value: e.target.value });
    }

    handleSubmit = (e) => {
        console.log('Your account has been created!' + this.state.value);
        e.preventDefault();
    }
    render() {
        return (
            <div className="FormSignUp">
                <form className="form" onSubmit={this.handleSubmit}>
                    <div>
                        <label>First Name</label>
                    </div>
                    <div>
                        <input type="text" placeholder="John" className="form-control"></input>
                    </div>
                    <div>
                        <label>Last Name</label>
                    </div>
                    <div>

                        <input type="text" placeholder="Doe" className="form-control"></input>
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
        )
    }
}

export default Form