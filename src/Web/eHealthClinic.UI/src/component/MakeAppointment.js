import React, { useState } from 'react';
import axios from 'axios';
import { useUser } from './common/UserContext';
import { TextField, Button, FormControl, InputLabel, Select, MenuItem, Box } from '@mui/material';
import {  LocalizationProvider, StaticDatePicker } from '@mui/x-date-pickers';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs'
import { useNavigate } from 'react-router-dom';
import { toast } from 'react-toastify';

function MakeAppointment() {
    const { user } = useUser();
    const navigate = useNavigate();
    const [selectedDate, setSelectedDate] = useState(null);
    const [timeSlot, setTimeSlot] = useState('');
    const [timeSlots, setTimeSlots] = useState([]);
    const [reason, setReason] = useState('');

    const handleDateChange = async (date) => {
        setSelectedDate(date);

        try {
            const response = await axios.get('http://localhost:5014/api/appointment/getTimeslots', {params: {
                    date: date.toISOString(),
                    hospitalCode: 'HMS01'
                
            }});

            setTimeSlots(response.data.timeslots);
        } catch (error) {
            console.error('Error fetching time slots:', error);
        }
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            await axios.post('http://localhost:5014/api/appointment', {
                date: selectedDate,
                timeslot: timeSlot,
                reason: reason,
                patientId: user.id
            });
            toast.success('Appointment created successfully! Now redirecting to appointment list.', {
                position: toast.POSITION.TOP_RIGHT
            });
            navigate("/list-appointments");
            // Optionally, provide success feedback, e.g. using a toast notification
        } catch (error) {
            console.error('Error saving appointment:', error);
            toast.error('Error saving appointment!', {
                position: toast.POSITION.TOP_RIGHT
            });
            // Optionally, provide error feedback
        }
    };

    return (
        <Box component="form" onSubmit={handleSubmit} spacing={3}>
            <LocalizationProvider dateAdapter={AdapterDayjs}>
                <StaticDatePicker
                    label="Appointment Date"
                    value={selectedDate}
                    disablePast={true}

                    onChange={handleDateChange}
                    renderInput={(params) => <TextField {...params} fullWidth required />}
                />
            </LocalizationProvider>
            <FormControl fullWidth variant="outlined" style={{ marginTop: '16px' }}>
                <InputLabel>Available Time Slots</InputLabel>
                <Select
                    value={timeSlot}
                    onChange={(e) => setTimeSlot(e.target.value)}
                    label="Available Time Slots"
                >
                    {timeSlots.map((slot) => (
                        <MenuItem key={slot} value={slot}>
                            {slot}
                        </MenuItem>
                    ))}
                </Select>
            </FormControl>
            <TextField
                variant="outlined"
                margin="normal"
                required
                fullWidth
                multiline
                rows={4}
                label="Reason for Appointment"
                value={reason}
                onChange={(e) => setReason(e.target.value)}
            />
            <Button
                type="submit"
                fullWidth
                variant="contained"
                color="primary"
                style={{ marginTop: '16px' }}
            >
                Make Appointment
            </Button>
        </Box>
    );
}

export default MakeAppointment;
