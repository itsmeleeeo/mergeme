import React, { useEffect, useState } from "react";

function EditProfile() {
    const [stackData, setStackData] = useState({});
    useEffect(() => {
        handleStackData();
    }, [])

    const handleStackData = async () => {
        const resp = await fetch('https://localhost:7033/stack')
        const data = await resp.json()
        setStackData(data);
        console.log(data)
        return data
    }
    return(
        <div>
            <div className="container">
                <div className="row">
                    <div className="col-lg-12">
                        <form>
                            <select>
                                {
                                    stackData.map(stack => <option key={stack.stackName }>{stack.stackName}</option>)
                                }
                            </select>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default EditProfile;