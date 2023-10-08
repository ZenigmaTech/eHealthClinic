import React, { useState } from 'react';
import axios from 'axios';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import Box from '@mui/material/Box';
import Container from '@mui/material/Container';
import Typography from '@mui/material/Typography';
import { useUser } from './common/UserContext';
import { toast } from 'react-toastify';
import { useNavigate } from 'react-router-dom';

function PatientLogin() {
    const { setUser } = useUser();
    const [patient, setPatient] = useState({
        email: '',
        password: ''
    });
    const navigate = useNavigate();

    const handleChange = e => {
        const { name, value } = e.target;
        setPatient(prevState => ({
            ...prevState,
            [name]: value
        }));
    };
    
    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await axios.post('http://localhost:5199/api/patient/login', {
                username: patient.email,
                password: patient.password
            });
            if (response.data.patient)
            {// Assuming the response data has a structure: { name: "...", patientId: "..." }
                setUser(response.data.patient);
                toast.success('Logged in successfully!', {
                    position: toast.POSITION.TOP_RIGHT
                });
                navigate("/");

            }
            else {
                toast.error('Login failed!', {
                    position: toast.POSITION.TOP_RIGHT
                });
            }
        } catch (error) {
            console.error('Login error:', error);
            // Handle error (e.g., show an error message to the user)
            toast.error('Login failed!', {
                position: toast.POSITION.TOP_RIGHT
            });
        }
    };

    return (
        <Container component="main" maxWidth="xs">
            <Typography component="h1" variant="h5">
                Patient Login
            </Typography>
            <Box component="form" onSubmit={handleSubmit} spacing={2}>
                <TextField
                    variant="outlined"
                    margin="normal"
                    required
                    fullWidth
                    label="Email"
                    name="email"
                    type="email"
                    value={patient.email}
                    onChange={handleChange}
                />
                <TextField
                    variant="outlined"
                    margin="normal"
                    required
                    fullWidth
                    label="Password"
                    name="password"
                    type="password"
                    value={patient.password}
                    onChange={handleChange}
                />
                <Button
                    type="submit"
                    fullWidth
                    variant="contained"
                    color="primary"
                    style={{ marginTop: '16px' }}
                >
                    Login Patient
                </Button>
            </Box>
        </Container>
    );
}

export default PatientLogin;
