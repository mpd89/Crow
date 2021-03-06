use [!!ProjectName!!_Daqument001]
exec sp_replicationdboption @dbname = N'!!ProjectName!!_Daqument001', @optname = N'merge publish', @value = N'true'

-- Adding the merge publication
use [!!ProjectName!!_Daqument001]
exec sp_addmergepublication @publication = N'!!ProjectName!!_Daqument001', @description = N'Merge publication of database ''!!ProjectName!!_Daqument001'' from Publisher ''!!MachineName!!\!!ServerInstance!!''.', @sync_mode = N'character', @retention = 60, @allow_push = N'true', @allow_pull = N'true', @allow_anonymous = N'true', @enabled_for_internet = N'false', @snapshot_in_defaultfolder = N'true', @compress_snapshot = N'false', @ftp_port = 21, @ftp_login = N'anonymous', @allow_subscription_copy = N'false', @add_to_active_directory = N'false', @dynamic_filters = N'false', @conflict_retention = 14, @keep_partition_changes = N'false', @allow_synctoalternate = N'false', @max_concurrent_merge = 0, @max_concurrent_dynamic_snapshots = 0, @use_partition_groups = null, @publication_compatibility_level = N'90RTM', @replicate_ddl = 1, @allow_subscriber_initiated_snapshot = N'false', @allow_web_synchronization = N'true', @allow_partition_realignment = N'true', @retention_period_unit = N'days', @conflict_logging = N'both', @automatic_reinitialization_policy = 0



exec sp_addpublication_snapshot @publication = N'!!ProjectName!!_Daqument001', @frequency_type = 4, @frequency_interval = 1, @frequency_relative_interval = 1, @frequency_recurrence_factor = 0, @frequency_subday = 1, @frequency_subday_interval = 5, @active_start_time_of_day = 500, @active_end_time_of_day = 235959, @active_start_date = 0, @active_end_date = 0, @job_login = null, @job_password = null, @publisher_security_mode = 1


use [!!ProjectName!!_Daqument001]
exec sp_addmergearticle @publication = N'!!ProjectName!!_Daqument001', @article = N'document_store', @source_owner = N'dbo', @source_object = N'document_store', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0

use [!!ProjectName!!_Daqument001]
exec sp_addmergearticle @publication = N'!!ProjectName!!_Daqument001', @article = N'drawing_objects', @source_owner = N'dbo', @source_object = N'drawing_objects', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


