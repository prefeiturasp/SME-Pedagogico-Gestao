import React from "react";
import PropTypes from "prop-types";

const ProfileItem = ({ roleId, onClick, profileName }) => {
  return (
    <div className="pt-3" name={roleId} onClick={onClick}>
      <div className="d-flex flex-fill profile-button align-items-center clickable">
        <div className="sc-text-size-0 d-flex flex-fill pl-4 profile-button-text">
          {profileName}
        </div>
        <div className="pr-2 d-flex align-items-center profile-button-text profile-button-icon">
          <div className="mr-2 profile-button-separator"></div>
          <i className="fas fa-share-square"></i>
        </div>
      </div>
    </div>
  );
};

ProfileItem.propTypes = {
  roleId: PropTypes.string.isRequired,
  onClick: PropTypes.func.isRequired,
  profileName: PropTypes.string.isRequired,
};

export default ProfileItem;
