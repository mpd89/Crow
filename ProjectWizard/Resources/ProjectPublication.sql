use [!!ProjectName!!]
exec sp_replicationdboption @dbname = N'!!ProjectName!!', @optname = N'merge publish', @value = N'true'

-- Adding the merge publication
use [!!ProjectName!!]
exec sp_addmergepublication @publication = N'!!ProjectName!!', @description = N'Merge publication of database ''!!ProjectName!!'' from Publisher ''!!MachineName!!\!!ServerInstance!!''.', @sync_mode = N'character', @retention = 60, @allow_push = N'true', @allow_pull = N'true', @allow_anonymous = N'true', @enabled_for_internet = N'false', @snapshot_in_defaultfolder = N'true', @compress_snapshot = N'false', @ftp_port = 21, @allow_subscription_copy = N'false', @add_to_active_directory = N'false', @dynamic_filters = N'false', @conflict_retention = 14, @keep_partition_changes = N'false', @allow_synctoalternate = N'false', @max_concurrent_merge = 0, @max_concurrent_dynamic_snapshots = 0, @use_partition_groups = null, @publication_compatibility_level = N'90RTM', @replicate_ddl = 1, @allow_subscriber_initiated_snapshot = N'false', @allow_web_synchronization = N'true', @allow_partition_realignment = N'true', @retention_period_unit = N'days', @conflict_logging = N'both', @automatic_reinitialization_policy = 0


use [!!ProjectName!!]
exec sp_addpublication_snapshot @publication = N'!!ProjectName!!', @frequency_type = 4, @frequency_interval = 1, @frequency_relative_interval = 1, @frequency_recurrence_factor = 0, @frequency_subday = 1, @frequency_subday_interval = 5, @active_start_time_of_day = 500, @active_end_time_of_day = 235959, @active_start_date = 0, @active_end_date = 0, @job_login = null, @job_password = null, @publisher_security_mode = 1


use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'aux_fieldmap', @source_owner = N'dbo', @source_object = N'aux_fieldmap', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'aux_template', @source_owner = N'dbo', @source_object = N'aux_template', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'aux_template_assoc', @source_owner = N'dbo', @source_object = N'aux_template_assoc', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'aux_subforms_info', @source_owner = N'dbo', @source_object = N'aux_subforms_info', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'aux_subforms_fields', @source_owner = N'dbo', @source_object = N'aux_subforms_fields', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'aux_forms_info', @source_owner = N'dbo', @source_object = N'aux_forms_info', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'aux_package', @source_owner = N'dbo', @source_object = N'aux_package', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'aux_tags', @source_owner = N'dbo', @source_object = N'aux_tags', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'DatagridViews', @source_owner = N'dbo', @source_object = N'DatagridViews', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'discrepancy', @source_owner = N'dbo', @source_object = N'discrepancy', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


--use [!!ProjectName!!]
--exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'document_association', @source_owner = N'dbo', @source_object = N'document_association', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'engineering_data', @source_owner = N'dbo', @source_object = N'engineering_data', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'equipment_type', @source_owner = N'dbo', @source_object = N'equipment_type', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'forms', @source_owner = N'dbo', @source_object = N'forms', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'forms_image', @source_owner = N'dbo', @source_object = N'forms_image', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'forms_config', @source_owner = N'dbo', @source_object = N'forms_config', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'forms_status', @source_owner = N'dbo', @source_object = N'forms_status', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'forms_me_status', @source_owner = N'dbo', @source_object = N'forms_me_status', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'forms_update', @source_owner = N'dbo', @source_object = N'forms_update', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'maint_number', @source_owner = N'dbo', @source_object = N'maint_number', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'mc1_number', @source_owner = N'dbo', @source_object = N'mc1_number', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'messages_sent', @source_owner = N'dbo', @source_object = N'messages_sent', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'messages_received', @source_owner = N'dbo', @source_object = N'messages_received', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1, @force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'messages', @source_owner = N'dbo', @source_object = N'messages', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'package', @source_owner = N'dbo', @source_object = N'package', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'package_documents', @source_owner = N'dbo', @source_object = N'package_documents', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0



use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'package_status', @source_owner = N'dbo', @source_object = N'package_status', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'ProjectImages', @source_owner = N'dbo', @source_object = N'ProjectImages', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'punchlist', @source_owner = N'dbo', @source_object = N'punchlist', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'ReferenceLibrary', @source_owner = N'dbo', @source_object = N'ReferenceLibrary', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'requirements', @source_owner = N'dbo', @source_object = N'requirements', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0



use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'sh1_number', @source_owner = N'dbo', @source_object = N'sh1_number', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0



use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'system_mnemonic', @source_owner = N'dbo', @source_object = N'system_mnemonic', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0



use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'system_number', @source_owner = N'dbo', @source_object = N'system_number', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0



use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'system_status', @source_owner = N'dbo', @source_object = N'system_status', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0



use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'tag_status', @source_owner = N'dbo', @source_object = N'tag_status', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0



use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'tags', @source_owner = N'dbo', @source_object = N'tags', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0



use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'TaskList', @source_owner = N'dbo', @source_object = N'TaskList', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'TaskStatus', @source_owner = N'dbo', @source_object = N'TaskStatus', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'tblForemanName', @source_owner = N'dbo', @source_object = N'tblForemanName', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'tblSpoolList', @source_owner = N'dbo', @source_object = N'tblSpoolList', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'tblWeldInchesEQLookup', @source_owner = N'dbo', @source_object = N'tblWeldInchesEQLookup', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0



use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'tblWeldersList', @source_owner = N'dbo', @source_object = N'tblWeldersList', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'tblWeldTracking', @source_owner = N'dbo', @source_object = N'tblWeldTracking', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'tblWeldTrackingAdvanced', @source_owner = N'dbo', @source_object = N'tblWeldTrackingAdvanced', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'tblWeldWPSLookup', @source_owner = N'dbo', @source_object = N'tblWeldWPSLookup', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'workpack_number', @source_owner = N'dbo', @source_object = N'workpack_number', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0


use [!!ProjectName!!]
exec sp_addmergearticle @publication = N'!!ProjectName!!', @article = N'WPS_fields', @source_owner = N'dbo', @source_object = N'WPS_fields', @type = N'table', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x0000000008034FF1,@force_reinit_subscription = 1, @column_tracking = N'false', @subset_filterclause = null, @vertical_partition = N'false', @verify_resolver_signature = 1, @allow_interactive_resolver = N'false', @fast_multicol_updateproc = N'true', @check_permissions = 0, @subscriber_upload_options = 0, @delete_tracking = N'true', @compensate_for_errors = N'false', @stream_blob_columns = N'false', @partition_options = 0



