Prerequisite:
1. Stanalone host.
2. User should have administrative rights.
3. Two applications installed on the the host:
a) Microsoft Visual Studio 2010 (.NET 4.0, C#)
b) Test installaion of 3CX Phone System version v12 with activated demo or any other commercial license.
WARNING: DO NOT RUN SAMPLES ON PRODUCTION (LIVE) enviroment

Usage:
	OMSamples [/?]|[SampleName arg1 arg2 ...]
List of samples:

SampleName: makecall
Implemented in OMSamples.Samples.MakeCallSample
Parameters:
	arg1 - Source of the call
	arg2 - Destination of the call

Description: Shows how to use PBXAPI.MakeCall() helper
--------------------------------------------------------------------------------
SampleName: display
Implemented in OMSamples.Samples.DisplayAllSample
Description: Shows information about all Parameters, Codecs, predefined conditions of the rules, IVRs and Extensions.
--------------------------------------------------------------------------------
SampleName: create_fax_extension
Implemented in OMSamples.Samples.CreateFaxExtensionSample
Parameters:
	arg1 - System extension number for new FaxExtension
	arg2 - SIP authentication ID. It can be different form the FaxExtension number
	arg3 - Authentication password. must be secure

Description: Creates FAX extension.
--------------------------------------------------------------------------------
SampleName: createbthelper
Implemented in OMSamples.Samples.CreateBlindTransferHelper
Parameters:
	arg1 - dial code of blind transfer helper

Description: Creates dialcode and parking extension for blind transfer helper
--------------------------------------------------------------------------------
SampleName: transfer_by_active_connection
Implemented in OMSamples.Samples.TransferByActiveConnectionSample
Parameters:
	arg1 - CallID taken from ActiveConnection
	arg2 - participant which will be replaced in the call
	arg3 - new participant who should replace participant specified by agr2

Description: Shows how to specify transfer call using ActiveConnection object. see PBXAPI.TransferCall()
--------------------------------------------------------------------------------
SampleName: dropcall
Implemented in OMSamples.Samples.DropCallSample
Parameters:
	arg1 - CallID taken from ActiveConnection
	arg2 - Participant which should be removed from the call

Description: Shows how to drop call using Call Control API
--------------------------------------------------------------------------------
SampleName: recordivrprompt
Implemented in OMSamples.Samples.RecordIVRPrompt
Parameters:
	arg1 - IVR number
	arg2 - Extension number
	arg3 - (optional) name of the file. File will be stored in standard IVR prompt path and will be appended with .wav extension

Description: If IVR and extension exist, are not busy and extension is registered then PBX will contact extension to record file and will set it as a new prompt for the IVR
--------------------------------------------------------------------------------
SampleName: refresh_line_registration
Implemented in OMSamples.Samples.RefreshLineRegistrationSample
Parameters:
	arg1 - Virtual extension number of External Line

Description: Ahoew how to refresh registration on VoIP provider Line
--------------------------------------------------------------------------------
SampleName: create_fwd_profile
Implemented in OMSamples.Samples.CreateFwdProfileSample
WARNING: This sample does not create valid profile of extension and modify extention configuration, it just show how to work with FwdProfile object.
Description: Creates FwdProfile objects for extension 100. Shows how to set current profile fow extension and attach rules to the profile.
--------------------------------------------------------------------------------
SampleName: update_extensions
Implemented in OMSamples.Samples.UpdateExtensionsSample
Description: Show how to update one of the Extension property for all extensions in the sysytem. This sample modifies 'PBX delivers audio' setting for all extensions
--------------------------------------------------------------------------------
SampleName: remove_extension
Implemented in OMSamples.Samples.RemoveExtensionSample
WARNING: It is destructive operation. Please be carefull with arguments
Parameters:
	arg1 - extension number

Description: Shows how to remove existing extension
--------------------------------------------------------------------------------
SampleName: phonebook
Implemented in OMSamples.Samples.PhoneBookSample
Description: Ahows how to create PhoneBookEntry for company and personal phonebooks
--------------------------------------------------------------------------------
SampleName: create_shared_parking
Implemented in OMSamples.Samples.CreateSharedParkingSample
Parameters:
	arg1 - name of shared parking place

Description: This sample adds Shared parking place. The name MUST start with 'SP'.
--------------------------------------------------------------------------------
SampleName: whisper
Implemented in OMSamples.Samples.WhisperSample
Parameters:
	arg1 - CallID taken from ActiveConnection
	arg2 - new participant who will gives the instructions to the participant specified by arg3
	arg3 - participant who requires instructions from new participant

Description: Shows how to use PBXAPI.WhisperTo()
--------------------------------------------------------------------------------
SampleName: invoke
Implemented in OMSamples.Samples.InvokeSample
Parameters:
	arg1 - command which should be invoked
	arg2, arg3 and so on - additional parameters for Invoke method - each additional parameter should be set as parameter_name=parameter_value

Description: Shows how to use PBXAPI.Invoke()
--------------------------------------------------------------------------------
SampleName: record_call
Implemented in OMSamples.Samples.RecordCallSample
Parameters:
	arg1 - CallID taken from ActiveCaonnection
	arg2 - who initiate record. (must be participant of the call
	arg3 - 1/0 - start/stop

Description: Shows how to start/stop recording of the call
--------------------------------------------------------------------------------
SampleName: bargein
Implemented in OMSamples.Samples.BargeInSample
Parameters:
	arg1 - Specisies active call. (see ActiveConnection object)
	arg2 - Specifies Extension number which sshould be barged in to the call

Description: Call Control API. Demostrates How to use PBXAPI.BargeIn()
--------------------------------------------------------------------------------
SampleName: update_stat
Implemented in OMSamples.Samples.UpdateStatSample
Description: This sample creates and continuously update Statistic object named 'MYSTAT'. After running this sample statistics 'MYSTAT' will be available for create_delete_stat sample
--------------------------------------------------------------------------------
SampleName: redirectdidtoextension
Implemented in OMSamples.Samples.RedirectDIDToExtension
WARNING: If script will be modifies destination for the existing DID rules. To repair configuration you need to restore configuration or revert changes manually
Parameters:
	arg1 - External line virtual number (DN)
	arg2 - DID number prefix
	arg3 - DID number length
	arg4 - Replace Prefix With

Description: This sample shows how to configure set of DID rules which will transform DID number to extension number.
 It modifies only DIDs rules which are not have different destincations for office and out of office hours
--------------------------------------------------------------------------------
SampleName: divertcall
Implemented in OMSamples.Samples.DivertCallSample
Parameters:
	arg1 - CallID taken from real active connection
	arg2 - Extension where call is ringing
	arg3 - new destination for the call
	arg4 -  optional. if '1' then call will be diverted to voicemail of the destination specified by arg3

Description: Shows how to use CallControl API to divert call.
--------------------------------------------------------------------------------
SampleName: remove_ivr
Implemented in OMSamples.Samples.RemoveIVRSample
WARNING: It is destructive operation. Please be carefull with arguments
Parameters:
	arg1 - system extension number of IVR

Description: Shows how to remove existing IVR
--------------------------------------------------------------------------------
SampleName: park_orbit_monitor
Implemented in OMSamples.Samples.ParkOrbitMonitorSample
Description: Monitors activity on Parking Orbits
--------------------------------------------------------------------------------
SampleName: set_outboundrule
Implemented in OMSamples.Samples.SetOutboundRuleSample
Description: Shows how to cobfigure outbound rules. This test shows preliminary 
--------------------------------------------------------------------------------
SampleName: dnproperty_save_delete
Implemented in OMSamples.Samples.DNPropertySaveDeleteSample
WARNING: modifies configuration of DN 100
Description: Shows how to modify(add) and delete DNProperty
--------------------------------------------------------------------------------
SampleName: listen
Implemented in OMSamples.Samples.ListenSample
Parameters:
	arg1 - CallID taken from ActiveConnection
	arg2 - Extension number which should listen the call

Description: Show how to use PBXAPI.Listen()
--------------------------------------------------------------------------------
SampleName: ext_line_rule_update
Implemented in OMSamples.Samples.ExternalLineRuleUpdateSample
WARNING: This sample will modify destination of existing rules. Line should be recreated after this test
Parameters:
	arg1 - Virtual extension number of the line

Description: This sample shows how to change destination of ExternalLineRule
--------------------------------------------------------------------------------
SampleName: transfer_by_dn
Implemented in OMSamples.Samples.TransferByDNSample
Parameters:
	arg1 - CallID taken from ActiveConnection
	arg2 - participant which will be replaced in the call
	arg3 - new participant who should replace participant specified by agr2

Description: Shows how to use PBXAPI.TransferCall()
--------------------------------------------------------------------------------
SampleName: receive_stat_notifications
Implemented in OMSamples.Samples.ReceiveStatNotificationsSample
Parameters:
	arg1 - Type of objects

Description: Shows notificatins for specific statistics object.
--------------------------------------------------------------------------------
SampleName: create_prompt_set
Implemented in OMSamples.Samples.CreatePromptSetSample
Description: Synthetic sample. It shows how to configure PromptSet object.
--------------------------------------------------------------------------------
SampleName: schedule_conference
Implemented in OMSamples.Samples.ScheduleTheConference
Parameters:
	arg1 - idstat/name
	arg2 - date and time
	arg3 - pin
	arg4 - Name of conference
	arg5 - (optional) Comma separated list of the participant who should be called at the beginning of conference (moderators)

Description: Schedule the conference
--------------------------------------------------------------------------------
SampleName: delete_from_profile
Implemented in OMSamples.Samples.DeleteFromProfileSample
WARNING: This sample damages configuration of extension 112. 112 should be deleted and recreated again after running this sample
Description: Shows how to remove extension rules. The rule, deleted by this samle, will disappear from all 
forwarding profiles where it was assigned to.
--------------------------------------------------------------------------------
SampleName: change_parkcodes
Implemented in OMSamples.Samples.ChangeParkCodesSample
WARNING: This sample changes global settings of PBX.
Parameters:
	arg1 - dial code to park call from the Parking Orbit
	arg2 - dial code to unpark call from the Parking Orbit

Description: Shows how to change dial codes of Parking Orbit
--------------------------------------------------------------------------------
SampleName: blacklist_monitor
Implemented in OMSamples.Samples.BlackListMonitor
Description: Sample of IP Black List manager
--------------------------------------------------------------------------------
SampleName: add_phone_model
Implemented in OMSamples.Samples.AddPhoneModelSample
Description: Creates PhoneModel object which describes capability for specific user agent
--------------------------------------------------------------------------------
SampleName: set_office_hours
Implemented in OMSamples.Samples.SetOfficeHoursSample
WARNING: You need to restore office hours after which test
Description: Shows how to setup 'Office Hours' of PBX
--------------------------------------------------------------------------------
SampleName: notifications_monitor
Implemented in OMSamples.Samples.NotificationsMonitorSample
Parameters:
	arg1 - Object type name

Description: Shows update notifications of specified type of the objects. All notifications will be shown if arg1 is not specified
--------------------------------------------------------------------------------
SampleName: show_gateway_parameters
Implemented in OMSamples.Samples.ShowGatewayParametersSample
Description: 
--------------------------------------------------------------------------------
SampleName: makecall2
Implemented in OMSamples.Samples.MakeCall2Sample
Parameters:
	arg1 - Source of the call
	arg2, arg3 and so on - Additional parameters for the call. in form paramname=paramvalue

Description: Shows how to use extended version of PBXAPI.MakeCall(string, Dictionary<string, string>) helper
--------------------------------------------------------------------------------
SampleName: dn_monitor
Implemented in OMSamples.Samples.DNmonitorSample
Description: Shows status of all DNs in the system(including active connections) and show all notifications about changes made in PBX configuration
--------------------------------------------------------------------------------
SampleName: add_ivr
Implemented in OMSamples.Samples.AddIVRSample
Parameters:
	arg1 - System extension number of new Digital receptionist

Description: Creates Digital Receptionist 'TestIVR' which has empty prompt and redirects call to Voicemail of the extension after 20 seconds
--------------------------------------------------------------------------------
SampleName: set_multicast_paging
Implemented in OMSamples.Samples.SetMulticastPagingSample
Parameters:
	arg1 - Paging group
	arg2 - Multicast address
	arg3 - Multicast port
	arg4 - codec. (PCMU, PCMA, GSM, G729 etc..)
	arg5 - ptime for RTP packets. use 20

Description: Shows how to set 'multicast' options for paging group. If only arg1 is provided then multicast settings will be removed and paging group will work as in 'multicall' mode
--------------------------------------------------------------------------------
SampleName: delete_current_profile
Implemented in OMSamples.Samples.DeleteCurrentProfileSample
WARNING: This sample damages configuration of extension 112. 112 should be deleted and recreated again after runing this sample
Description: Requires existing extension 112. Removes profile which is currently seleted in extension configuration
--------------------------------------------------------------------------------
SampleName: create_delete_stat
Implemented in OMSamples.Samples.CreateDeleteStatSample
Description: This sample shows how to delete and create Statistics object. 
Statistics 'MYSTAT' should be initialized before runing this sample. 
(use update_stat sample)
--------------------------------------------------------------------------------
SampleName: change_vmbox_info
Implemented in OMSamples.Samples.ChangeVMBoxInfoSample
Parameters:
	arg1 - extension number

Description: Sets voicemail box information for the specified extension. 
Number of messages is hardcoded and set to 1 new message and 2 messages in total.
--------------------------------------------------------------------------------
SampleName: add_extension_with_property
Implemented in OMSamples.Samples.AddExtensionWithPropertySample
Parameters:
	arg1 - extension number

Description: Creates new extension and sets DNProperty TEST_PROPERTY to string 'justFortest'
--------------------------------------------------------------------------------
