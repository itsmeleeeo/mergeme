import React, { useEffect, useState } from "react";
import { Link } from 'react-router-dom';
import Footer from "./Footer";

function EditProfile() {
    const name = sessionStorage.getItem('name');
    const user = JSON.parse(name)
    const userId = user.status;

    const [stackData, setStackData] = useState({});
    const [firstName, setFirstname] = useState('');
    const [lastName, setLastName] = useState('');
    const [position, setPosition] = useState('');
    const [stackOne, setStackOne] = useState('');
    const [stackTwo, setStackTwo] = useState('');
    const [stackThree, setStackThree] = useState('');
    const [userbio, setUserbio] = useState('');
    const [profileImageUrl, setProfileImageUrl] = useState(''); 

    useEffect(() => {
        const userName = JSON.parse(name)

        for(const item of userName.result) {
            if(item.type === 'FirstName') {
                setFirstname(item.value);
            }else if(item.type === 'LastName') {
                setLastName(item.value);
                break;
            }
        }
    
        handleStackData();
        SelectedStack();
        console.log(profileImageUrl);
    }, [profileImageUrl, name])

    const handleStackData = async () => {
        const resp = await fetch('https://localhost:7033/stack')
        const data = await resp.json()
        setStackData(data);
        console.log(data);
    }

    const SelectedStack = () => {
        let stackOneSelected = document.querySelector('.stackOneSelected');
        const images = {
            Angular: 'https://storage.cloud.google.com/mergeme/Angular-JS-01.png',
            'C++': 'https://storage.cloud.google.com/mergeme/C%2B%2B-01.png',
            C: 'https://storage.cloud.google.com/mergeme/C-01.png',
            'C#': 'https://storage.cloud.google.com/mergeme/C-Sharp-01.png',
            Clojure: 'https://storage.cloud.google.com/mergeme/Clojure-01.png',
            Drupal: 'https://storage.cloud.google.com/mergeme/Drupal-Icon-01.png',
            Electron: 'https://storage.cloud.google.com/mergeme/Electron-01.png',
            Firebase: 'https://storage.cloud.google.com/mergeme/Firebase-02.png',
            GraphQL: 'https://storage.cloud.google.com/mergeme/GraphQL-01.png',
            Haskell: 'https://storage.cloud.google.com/mergeme/Haskell-logo-vector-01.png',
            Ionic: 'https://storage.cloud.google.com/mergeme/Ionic-01.png',
            JQuery: 'https://storage.cloud.google.com/mergeme/JQuery-01.png',
            Java: 'https://storage.cloud.google.com/mergeme/Java-01.png',
            JavaScript: 'https://storage.cloud.google.com/mergeme/JavaScript-01.png',
            Kubernets: 'https://storage.cloud.google.com/mergeme/Kubernets-01.png',
            '.Net': 'https://storage.cloud.google.com/mergeme/Microsoft-Dotnet-01.png',
            NodeJs: 'https://storage.cloud.google.com/mergeme/Node-JS-01.png',
            PHP: 'https://storage.cloud.google.com/mergeme/PHP-01.png',
            Perl: 'https://storage.cloud.google.com/mergeme/Perl-01.png',
            Python: 'https://storage.cloud.google.com/mergeme/Python-01.png',
            R: 'https://storage.cloud.google.com/mergeme/R-Lang-01.png',
            React: 'https://storage.cloud.google.com/mergeme/React-01.png',
            Rust: 'https://storage.cloud.google.com/mergeme/Rust-01.png',
            Typescript: 'https://storage.cloud.google.com/mergeme/Typescript-02.png',
            Vue: 'https://storage.cloud.google.com/mergeme/Vue-JS-01.png'
          };
        
        stackOneSelected.addEventListener('change', (e) => {
            let selectedStack = e.target.value;

            if (images[selectedStack]) {
               setProfileImageUrl(images[selectedStack]);
              } else {
                setProfileImageUrl('');
              }
        })
    }

    const handleSubmit = async () => {

        const editUser = {
            firstName,
            lastName,
            position,
            profileImageUrl,
            userbio
        };

        const userStack = {
            stackOne,
            stackTwo,
            stackThree
        };

        await fetch(`https://localhost:7033/developer/${userId}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json' },
            body: JSON.stringify(editUser)
        }).then((resp) => resp.json())
            .then((editUser) => {
                console.log('Success:', editUser);
            }).catch((err) => {
                console.error('Error:', err);
            });

        await fetch(`https://localhost:7033/developerstacks/${userId}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json' },
            body: JSON.stringify(userStack)
        }).then((resp) => resp.json())
            .then((userStack) => {
                console.log('Success:', userStack);
            }).catch((err) => {
                console.error('Error:', err);
        });
    }

    return(
        <div className="container">
            <div className="row">
                <div className="col-lg-12">
                    <form onSubmit={handleSubmit}>
                        <div>
                            <label className="form-label">Enter your first name</label>
                            <input type="text" className="form-control" value={firstName} readOnly />
                        </div>
                        <div>
                            <label className="form-label">Enter your last name</label>
                            <input type="text" className="form-control" value={lastName} readOnly />
                        </div>
                        <div>
                            <label className="form-label">Enter your position</label>
                            <input type="text" placeholder="eg.Full-Stack Developer" className="form-control" value={position} onChange={(e) => setPosition(e.target.value)} required />
                        </div>
                        <div>
                            <label className="form-label">Select your first option</label>
                            <div id="emailHelp" className="form-text">Choose the first language in which you are most proficient and it will be your profile picture</div>
                            <select onChange={(e) => setStackOne(e.target.value)} className="form-select stackOneSelected" aria-label="Default select example">
                                {stackData && stackData.length > 0 && stackData.map((stack, i) => (
                                    <option key={i} value={stack.stackName}>{stack.stackName}</option>
                                ))}
                            </select>
                        </div>
                        <div>
                            <label className="form-label">Select your second option</label>
                            <select onChange={(e) => setStackTwo(e.target.value)} className="form-select" aria-label="Default select example">
                                {stackData && stackData.length > 0 && stackData.map((stack, i) => (
                                    <option key={i} value={stack.stackName}>{stack.stackName}</option>
                                ))}
                            </select>
                        </div>
                        <div>
                            <label className="form-label">Select your third option</label>
                            <select onChange={(e) => setStackThree(e.target.value)} className="form-select" aria-label="Default select example">
                                {stackData && stackData.length > 0 && stackData.map((stack, i) => (
                                    <option key={i} value={stack.stackName}>{stack.stackName}</option>
                                ))}
                            </select>
                        </div>
                        <div>
                            <label className="form-label">Type your bio</label>
                            <textarea className="form-control" placeholder="Leave a comment here" value={userbio} onChange={(e) => setUserbio(e.target.value)}></textarea>
                        </div>
                        <div className="dsp-around mt-10 mb-30">
                            <input type="submit" value="Update" className="devSubmitForm" />
                            <Link to="/dashboard/developer">
                                <button className="goBackBtn">Back to Dashboard</button>
                            </Link>
                            <input type="reset" value="Clear" className="clearForm" />
                        </div>
                    </form>
                </div>
                <Footer />
            </div>
        </div>
    )
}

export default EditProfile;