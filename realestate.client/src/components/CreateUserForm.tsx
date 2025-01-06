import React, { useState } from "react";

// Define the types for the form state
interface UserCreateModel {
    firstName: string;
    lastName: string;
    email: string;
    password: string;
}

const CreateUserForm: React.FC = () => {
    // Use state with types for the form data and status message
    const [formData, setFormData] = useState<UserCreateModel>({
        firstName: "",
        lastName: "",
        email: "",
        password: "",
    });
    const [statusMessage, setStatusMessage] = useState<string>("");

    // Handle changes to input fields
    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const { name, value } = e.target;
        setFormData((prevData) => ({
            ...prevData,
            [name]: value,
        }));
    };

    // Handle form submission
    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();

        // Prepare the data to send to the server
        const userData = {
            firstName: formData.firstName,
            lastName: formData.lastName,
            email: formData.email,
            password: formData.password,
        };

        try {
            // Make the POST request using fetch
            const response = await fetch("https://localhost:7124/api/users", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json", // Indicate we're sending JSON
                },
                body: JSON.stringify(userData), // Convert the object to a JSON string
            });

            // Check if the response was successful
            if (!response.ok) {
                const errorData = await response.json(); // Parse the error message
                setStatusMessage(`Error: ${errorData.statusMessage || 'Unknown error'}`);
                return;
            }

            // Parse the successful response
            const data = await response.json();
            setStatusMessage(data.statusMessage); // Handle success response
        } catch (error) {
            // Handle network errors or other unexpected errors
            setStatusMessage(`Error: ${error instanceof Error ? error.message : 'Unknown error'}`);
        }
    };

    return (
        <div>
            <h2>Create User</h2>
            {statusMessage && <p>{statusMessage}</p>}
            <form onSubmit={handleSubmit}>
                <div>
                    <label>First Name:</label>
                    <input
                        type="text"
                        name="firstName"
                        value={formData.firstName}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div>
                    <label>Last Name:</label>
                    <input
                        type="text"
                        name="lastName"
                        value={formData.lastName}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div>
                    <label>Email:</label>
                    <input
                        type="email"
                        name="email"
                        value={formData.email}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div>
                    <label>Password:</label>
                    <input
                        type="password"
                        name="password"
                        value={formData.password}
                        onChange={handleChange}
                        required
                    />
                </div>
                <button type="submit">Create User</button>
            </form>
        </div>
    );
};

export default CreateUserForm;
