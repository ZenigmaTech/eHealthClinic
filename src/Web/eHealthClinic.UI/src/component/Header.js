import React, { useState } from 'react';
import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import { Link } from 'react-router-dom';
import Typography from '@mui/material/Typography';
import IconButton from '@mui/material/IconButton';
import Menu from '@mui/material/Menu';
import MenuItem from '@mui/material/MenuItem';
import MenuIcon from '@mui/icons-material/Menu';
import LocalHospitalIcon from '@mui/icons-material/LocalHospital'; // This icon suits the healthcare theme.
import { useUser } from './common/UserContext';

function Header() {
    const [anchorEl, setAnchorEl] = useState(null);
    const { user } = useUser();
    const handleClick = (event) => {
        setAnchorEl(event.currentTarget);
    };

    const handleClose = () => {
        setAnchorEl(null);
    };

    return (
        <AppBar position="static" style={{ backgroundColor: '#a8324a' }}>
            <Toolbar>
                <IconButton edge="start" color="inherit" onClick={handleClick}>
                    <MenuIcon />
                </IconButton>
                <Menu
                    anchorEl={anchorEl}
                    open={Boolean(anchorEl)}
                    onClose={handleClose}
                >
                        <MenuItem onClick={handleClose} component={Link} to="/">Home</MenuItem>

                    {user ? (
                                              <>
                        <MenuItem onClick={handleClose} component={Link} to="/make-appointment">Make Appointment</MenuItem>
                        <MenuItem onClick={handleClose} component={Link} to="/list-appointments">List Appointments</MenuItem>
                                          </>
                    ) : (
                        <>
                            <MenuItem onClick={handleClose} component={Link} to="/register">Register as Patient</MenuItem>
                            <MenuItem onClick={handleClose} component={Link} to="/login">Login</MenuItem>
                        </>
                    )}
                </Menu>
                <LocalHospitalIcon style={{ marginRight: '10px' }} />
                <Typography variant="h6" style={{ flexGrow: 1, textAlign: 'center' }}>
                    eHealth Clinic Management System
                </Typography>
                {user ? (
                    <>
                        {/* Display user's name */}
                        <Typography variant="subtitle1" style={{ flexGrow: 1, textAlign: 'right' }}>
                            Hello, {user.name}
                        </Typography>
                        {/* ... Other logged-in specific UI ... */}
                    </>
                ) : (
                    <>
                        {/* Display items for non-logged-in users */}
                        {/* ... e.g., Register and Login menu items ... */}
                    </>
                )}
            </Toolbar>
        </AppBar>
    );
}

export default Header;
