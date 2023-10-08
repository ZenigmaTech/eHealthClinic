import React, { useState, useEffect } from 'react';
import { useUser } from './common/UserContext';
import axios from 'axios';
import { Table, TableBody, TableCell, TableHead, TableRow, Paper } from '@mui/material';

function AppointmentsList() {
    const { user } = useUser();
    const [appointments, setAppointments] = useState([]);

    useEffect(() => {
        if (user && user.id) {
            const fetchAppointments = async () => {
                try {
                    const response = await axios.get('http://localhost:5014/api/appointment', {
                        params: { patientId: user.id }
                    });
                    setAppointments(response.data.appointments);
                } catch (error) {
                    console.error('Error fetching appointments:', error);
                }
            };

            fetchAppointments();
        }
    }, [user]);

    return (
        <Paper elevation={3}>
            <Table>
                <TableHead>
                    <TableRow>
                        <TableCell>Date</TableCell>
                        <TableCell>Time Slot</TableCell>
                        <TableCell>Reason</TableCell>
                        {/* Add other relevant columns if needed */}
                    </TableRow>
                </TableHead>
                <TableBody>
                    {appointments.map((appointment) => (
                        <TableRow key={appointment.id}>
                            <TableCell>{appointment.date}</TableCell>
                            <TableCell>{appointment.timeslot}</TableCell>
                            <TableCell>{appointment.reason}</TableCell>
                            {/* Add other relevant cells if needed */}
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        </Paper>
    );
}

export default AppointmentsList;
