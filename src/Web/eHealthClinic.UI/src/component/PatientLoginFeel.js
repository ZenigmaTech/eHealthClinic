import React, { useState } from 'react';
import { Box, Typography, Button, TextField, Container, Paper } from '@mui/material';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';
import { useUser } from './common/UserContext';
import { toast } from 'react-toastify';

function LoginPage() {
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
            const response = await axios.post('http://localhost:40001/api/patient/login', {
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
        <Box 
            display="flex"
            alignItems="center"
            flexDirection={'row'}
            justifyContent="center"
            sx={{ width: 1, height: "70vh" }}
        >
            <Paper elevation={5} style={{ padding: '40px', width: '100%', maxWidth: '400px', }}>
                <Box textAlign="center" mb={4}>
                    <Typography variant="h4" color="primary">
                        Welcome to eHealth
                    </Typography>
                    <Typography variant="subtitle1" color="textSecondary" style={{ marginTop: '10px' }}>
                        Your health is our utmost priority.
                    </Typography>
                </Box>
                <form onSubmit={handleSubmit}>
                    <TextField 
                        variant="outlined" 
                        margin="normal" 
                        required fullWidth 
                        label="Username"
                        type='email' 
                        name="email"
                        value={patient.email} 
                        onChange={handleChange}
                    />
                    <TextField 
                        variant="outlined" 
                        margin="normal" 
                        required fullWidth 
                        label="Password" 
                        type="password"
                        name="password" 
                        value={patient.password} 
                        onChange={handleChange}
                    />
                    <Button 
                        type="submit" 
                        fullWidth 
                        variant="contained" 
                        color="primary" 
                        style={{ marginTop: '20px' }}
                    >
                        Login
                    </Button>
                </form>
            </Paper>
        </Box>
    );
}

export default LoginPage;
