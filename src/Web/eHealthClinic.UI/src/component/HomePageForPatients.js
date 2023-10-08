import React from 'react';
import { Box, Typography, Button, Container, Grid, Card, CardContent } from '@mui/material';
import { useNavigate } from 'react-router-dom';
import { useUser } from './common/UserContext';

function HomePageForPatients() {
    const { user } = useUser();
    const history = useNavigate();

    const navigateToBook = () => {
        history('/make-appointment');
    };
    const navigateToList = () => {
        history('/list-appointments');
    };


    return (
        <Container maxWidth="lg">
            <Box textAlign="center" my={8}>
                <Typography variant="h2" color="primary">
                    Welcome, {user.name}
                </Typography>
                <Typography variant="h6" color="textSecondary" gutterBottom>
                    Your health journey, simplified.
                </Typography>

                <Grid container spacing={4} style={{ marginTop: '40px' }}>
                    <Grid item xs={12} md={6}>
                        <Card>
                            <CardContent>
                                <Typography variant="h6" gutterBottom>
                                    View Appointments
                                </Typography>
                                <Typography color="textSecondary">
                                    Check your upcoming appointments.
                                </Typography>
                                <Box mt={2}>
                                    <Button variant="contained" color="primary" onClick={navigateToList}>
                                        Show All
                                    </Button>
                                </Box>
                            </CardContent>
                        </Card>
                    </Grid>
                    <Grid item xs={12} md={6}>
                        <Card>
                            <CardContent>
                                <Typography variant="h6" gutterBottom>
                                    Book an Appointment
                                </Typography>
                                <Typography color="textSecondary">
                                    Schedule your next visit.
                                </Typography>
                                <Box mt={2}>
                                    <Button variant="contained" color="primary" onClick={navigateToBook}>
                                        Book Now
                                    </Button>
                                </Box>
                            </CardContent>
                        </Card>
                    </Grid>
                </Grid>

            </Box>
        </Container>
    );
}

export default HomePageForPatients;
