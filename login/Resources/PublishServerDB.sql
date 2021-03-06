use [!!SiteName!!_ServerDB]
exec sp_replicationdboption @dbname = N'!!SiteName!!_ServerDB', @optname = N'merge publish', @value = N'true'

-- Adding the merge publication
use [!!SiteName!!_ServerDB]
exec sp_addmergepublication @publication = N'!!SiteName!!_ServerDB', @description = N'Merge publication of database ''!!SiteName!!_ServerDB'' from Publisher ''!!PUB!!''.', @sync_mode = N'character', @retention = 14, @allow_push = N'true', @allow_pull = N'true', @allow_anonymous = N'true', @enabled_for_internet = N'false', @snapshot_in_defaultfolder = N'true', @compress_snapshot = N'false', @ftp_port = 21, @ftp_login = N'anonymous', @allow_subscription_copy = N'false', @add_to_active_directory = N'false', @dynamic_filters = N'false', @conflict_retention = 14, @keep_partition_changes = N'false', @allow_synctoalternate = N'false', @max_concurrent_merge = 0, @max_concurrent_dynamic_snapshots = 0, @use_partition_groups = null, @publication_compatibility_level = N'90RTM', @replicate_ddl = 1, @allow_subscriber_initiated_snapshot = N'false', @allow_web_synchronization = N'true', @allow_partition_realignment = N'true', @retention_period_unit = N'days', @conflict_logging = N'both', @automatic_reinitialization_policy = 0

exec sp_addpublication_snapshot @publication = N'!!SiteName!!_ServerDB', @frequency_type = 4, @frequency_interval = 14, @frequency_relative_interval = 1, @frequency_recurrence_factor = 0, @frequency_subday = 1, @frequency_subday_interval = 5, @active_start_time_of_day = 500, @active_end_time_of_day = 235959, @active_start_date = 0, @active_end_date = 0, @job_login = null, @job_password = null, @publisher_security_mode = 1


use [!!SiteName!!_ServerDB]
exec sp_addmergearticle @publication = N'!!SiteName!!_ServerDB', @article = N'bugsug', @source_owner = N'dbo', @source_object = N'bugsug', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0



use [!!SiteName!!_ServerDB]
exec sp_addmergearticle @publication = N'!!SiteName!!_ServerDB', @article = N'ClientAccess', @source_owner = N'dbo', @source_object = N'ClientAccess', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!SiteName!!_ServerDB]
exec sp_addmergearticle @publication = N'!!SiteName!!_ServerDB', @article = N'company', @source_owner = N'dbo', @source_object = N'company', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0



use [!!SiteName!!_ServerDB]
exec sp_addmergearticle @publication = N'!!SiteName!!_ServerDB', @article = N'configuration', @source_owner = N'dbo', @source_object = N'configuration', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!SiteName!!_ServerDB]
exec sp_addmergearticle @publication = N'!!SiteName!!_ServerDB', @article = N'CostCodes', @source_owner = N'dbo', @source_object = N'CostCodes', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0



use [!!SiteName!!_ServerDB]
exec sp_addmergearticle @publication = N'!!SiteName!!_ServerDB', @article = N'discipline', @source_owner = N'dbo', @source_object = N'discipline', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!SiteName!!_ServerDB]
exec sp_addmergearticle @publication = N'!!SiteName!!_ServerDB', @article = N'Employee', @source_owner = N'dbo', @source_object = N'Employee', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!SiteName!!_ServerDB]
exec sp_addmergearticle @publication = N'!!SiteName!!_ServerDB', @article = N'Employee_TSGroup', @source_owner = N'dbo', @source_object = N'Employee_TSGroup', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,  @force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!SiteName!!_ServerDB]
exec sp_addmergearticle @publication = N'!!SiteName!!_ServerDB', @article = N'ErrorLog', @source_owner = N'dbo', @source_object = N'ErrorLog', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0



use [!!SiteName!!_ServerDB]
exec sp_addmergearticle @publication = N'!!SiteName!!_ServerDB', @article = N'groups', @source_owner = N'dbo', @source_object = N'groups', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0



use [!!SiteName!!_ServerDB]
exec sp_addmergearticle @publication = N'!!SiteName!!_ServerDB', @article = N'levels', @source_owner = N'dbo', @source_object = N'levels', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0



use [!!SiteName!!_ServerDB]
exec sp_addmergearticle @publication = N'!!SiteName!!_ServerDB', @article = N'notes', @source_owner = N'dbo', @source_object = N'notes', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0



use [!!SiteName!!_ServerDB]
exec sp_addmergearticle @publication = N'!!SiteName!!_ServerDB', @article = N'owner', @source_owner = N'dbo', @source_object = N'owner', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0



use [!!SiteName!!_ServerDB]
exec sp_addmergearticle @publication = N'!!SiteName!!_ServerDB', @article = N'Permissions', @source_owner = N'dbo', @source_object = N'Permissions', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0



use [!!SiteName!!_ServerDB]
exec sp_addmergearticle @publication = N'!!SiteName!!_ServerDB', @article = N'projects', @source_owner = N'dbo', @source_object = N'projects', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0



use [!!SiteName!!_ServerDB]
exec sp_addmergearticle @publication = N'!!SiteName!!_ServerDB', @article = N'project_status', @source_owner = N'dbo', @source_object = N'project_status', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0



use [!!SiteName!!_ServerDB]
exec sp_addmergearticle @publication = N'!!SiteName!!_ServerDB', @article = N'SystemFeatures', @source_owner = N'dbo', @source_object = N'SystemFeatures', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0



use [!!SiteName!!_ServerDB]
exec sp_addmergearticle @publication = N'!!SiteName!!_ServerDB', @article = N'SystemImages', @source_owner = N'dbo', @source_object = N'SystemImages', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!SiteName!!_ServerDB]
exec sp_addmergearticle @publication = N'!!SiteName!!_ServerDB', @article = N'TSGroup', @source_owner = N'dbo', @source_object = N'TSGroup', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1, @force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!SiteName!!_ServerDB]
exec sp_addmergearticle @publication = N'!!SiteName!!_ServerDB', @article = N'user_discipline', @source_owner = N'dbo', @source_object = N'user_discipline', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1, @identityrangemanagementoption = N'manual', @force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0



use [!!SiteName!!_ServerDB]
exec sp_addmergearticle @publication = N'!!SiteName!!_ServerDB', @article = N'user_group', @source_owner = N'dbo', @source_object = N'user_group', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1, @identityrangemanagementoption = N'manual', @force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0



use [!!SiteName!!_ServerDB]
exec sp_addmergearticle @publication = N'!!SiteName!!_ServerDB', @article = N'user_levels', @source_owner = N'dbo', @source_object = N'user_levels', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1, @identityrangemanagementoption = N'manual', @force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0



use [!!SiteName!!_ServerDB]
exec sp_addmergearticle @publication = N'!!SiteName!!_ServerDB', @article = N'user_owner', @source_owner = N'dbo', @source_object = N'user_owner', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1, @identityrangemanagementoption = N'manual', @force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0



use [!!SiteName!!_ServerDB]
exec sp_addmergearticle @publication = N'!!SiteName!!_ServerDB', @article = N'user_projects', @source_owner = N'dbo', @source_object = N'user_projects', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1, @identityrangemanagementoption = N'manual', @force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0



use [!!SiteName!!_ServerDB]
exec sp_addmergearticle @publication = N'!!SiteName!!_ServerDB', @article = N'userInfo', @source_owner = N'dbo', @source_object = N'userInfo', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0



use [!!SiteName!!_ServerDB]
exec sp_addmergearticle @publication = N'!!SiteName!!_ServerDB', @article = N'userlog', @source_owner = N'dbo', @source_object = N'userlog', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0



