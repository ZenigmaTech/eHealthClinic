import React from 'react';
import { Box, Typography, Button, Container } from '@mui/material';
import { useNavigate } from 'react-router-dom';

function HomePageForVisitors() {
    const history = useNavigate();

    const navigateToRegister = () => {
        history('/register');
    };

    const navigateToLogin = () => {
        history('/login');
    };

    return (
        <Container maxWidth="lg">
            <Box textAlign="center" my={8}>
                <Typography variant="h2" color="primary">
                    Welcome to eHealth Clinic
                </Typography>
                <Typography variant="h6" color="textSecondary" gutterBottom>
                    We prioritize your well-being
                </Typography>
                <Box mt={4}>
                    <img 
                        src="https://www.medicalcenterturkey.com/wp-content/uploads/2019/11/american-hospital-building.png" 
                        alt="eHealth Clinic" 
                        width="100%" 
                        style={{ borderRadius: '10px', boxShadow: '0px 4px 12px rgba(0, 0, 0, 0.1)' }} 
                    />
                </Box>
                <Box mt={6}>
                    <Typography variant="h4" gutterBottom>
                        Our Commitment
                    </Typography>
                    <Typography color="textSecondary">
                        Comprehensive care tailored to your unique health needs.
                    </Typography>
                </Box>
                <Box mt={6}>
                    <Button variant="contained" color="primary" onClick={navigateToRegister} style={{ marginRight: '20px' }}>
                        Register
                    </Button>
                    <Button variant="contained" color="secondary" onClick={navigateToLogin}>
                        Login
                    </Button>
                </Box>
            </Box>
        </Container>
    );
}

export default HomePageForVisitors;
