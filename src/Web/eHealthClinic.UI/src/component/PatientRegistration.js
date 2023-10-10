import React, { useState } from 'react';
import axios from 'axios';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import Box from '@mui/material/Box';
import Container from '@mui/material/Container';
import Typography from '@mui/material/Typography';
import { toast } from 'react-toastify';

function PatientRegistration() {
    const [patient, setPatient] = useState({
        name: '',
        mail: '',
        phone: '',
        address: ''
    });

    const handleChange = e => {
        const { name, value } = e.target;
        setPatient(prevState => ({
            ...prevState,
            [name]: value
        }));
    };

    const handleSubmit = async e => {
        e.preventDefault();

        try {
            const response = await axios.post('http://localhost:40001/api/patient', patient);
            if (response.data)
            {// Assuming the response data has a structure: { name: "...", patientId: "..." }
                toast.success('Patient registered successfully!', {
                    position: toast.POSITION.TOP_RIGHT
                });
            }
            else {
                toast.error('Patient registration failed!', {
                    position: toast.POSITION.TOP_RIGHT
                });
            }
        } catch (error) {
            console.error('Patient registration error:', error);
            // Handle error (e.g., show an error message to the user)
            toast.error('Patient registration failed!', {
                position: toast.POSITION.TOP_RIGHT
            });
        }
    };

    return (
        <Container component="main" maxWidth="xs">
            <Typography component="h1" variant="h5">
                Patient Registration
            </Typography>
            <Box component="form" onSubmit={handleSubmit} spacing={2}>
                <TextField
                    variant="outlined"
                    margin="normal"
                    required
                    fullWidth
                    label="Name"
                    name="name"
                    value={patient.name}
                    onChange={handleChange}
                />
                <TextField
                    variant="outlined"
                    margin="normal"
                    required
                    fullWidth
                    label="Email"
                    name="mail"
                    type="email"
                    value={patient.mail}
                    onChange={handleChange}
                />
                <TextField
                    variant="outlined"
                    margin="normal"
                    required
                    fullWidth
                    label="Phone"
                    name="phone"
                    value={patient.phone}
                    onChange={handleChange}
                />
                <TextField
                    variant="outlined"
                    margin="normal"
                    required
                    fullWidth
                    label="Address"
                    name="address"
                    value={patient.address}
                    onChange={handleChange}
                />
                <Button
                    type="submit"
                    fullWidth
                    variant="contained"
                    color="secondary"
                    style={{ marginTop: '16px' }}
                >
                    Register Patient
                </Button>
            </Box>
        </Container>
    );
}

export default PatientRegistration;
