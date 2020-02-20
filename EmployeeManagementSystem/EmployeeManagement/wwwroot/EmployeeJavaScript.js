function activeLogin() {
	$(document).ready(function () {
		$("#LoginDiv").show();
	});
	deActiveParagraph();
	deActiveListView();
}
function deActiveLogin() {
	$(document).ready(function () {
		$("#LoginDiv").hide();
	});
}
function activeEmployeeManagement() {
	$(document).ready(function () {
		$("#EmployeeManagement").show();
	});
	deActiveParagraph();
	deActiveListView();
}
function deActiveEmployeeManagement() {
	$(document).ready(function () {
		$("#EmployeeManagement").hide();
	});
}
function activeParagraph() {
	$(document).ready(function () {
		$("#paragraph").show();
	});
	deActiveEmployeeManagement();
	deActiveLogin();
	deActiveListView();
}
function deActiveParagraph() {
	$(document).ready(function () {
		$("#paragraph").hide();
	});
}
function activeListView() {
	$(document).ready(function () {
		$("#ListView").show();
	});
	deActiveParagraph();
	deActiveEmployeeManagement();
	deActiveLogin();
}
function deActiveListView() {
	$(document).ready(function (){
		$("#ListView").hide();
	});
}
function clearListView() {
	$(document).ready(function () {
		$("#ListTable").html("");
	});
}
function LoginAction() {
	$(document).ready(function () {
		var formData = new FormData;
		formData.append('name', $("#LoginName").val());
		formData.append('userId', $("#LoginPassword").val());
		formData.append('mobile', $("#LoginMobile").val());
		$.ajax({
			url: "api/login",
			type: 'POST',
			cache: false,
			contentType: false,
			processData: false,
			data: formData,
			success: function (response) {
				// Replace the div's content with the page method's return.
				alert(response);
			},
			error: function (response) {
				console.log(response);
				alert(response)
			}
		});
	});
}
function RegisterAction() {
	$(document).ready(function () {
		var formData = new FormData;
		formData.append("name", $("#RegisterName").val());
		formData.append("mobile", $("#RegisterMobile").val());
		formData.append("salary", $("#RegisterSalary").val());
		formData.append("city", $("#RegisterCity").val());

		$.ajax({
			url: "api/add",
			type: 'POST',
			cache: false,
			contentType: false,
			processData: false,
			data: formData,
			success: function (response) {
				// Replace the div's content with the page method's return.
				alert(response);
			},
			error: function (response) {
				alert(response);
			}
		});
	});
}
function GetAllEmployee() {
	$(document).ready(function () {
		$.ajax({
			url: "api/getEmplyees",
			dataType: "json",
			type: 'GET',
			success: function (data) {
				//console.log(data);
				//$("#ListView").append(JSON.stringify(data));
				data: JSON.stringify(data);
				var tablehtml = '<tr><td>Id</td><td>Name</td><td>Mobile</td><td>Salary</td><td>City</td><tr>';
				$.each(data, function (i, item) {
					tablehtml += '<tr><td>' + item.userId + '</td><td>' + item.name + '</td><td>' + item.mobile
						+ '</td><td>' + item.salary + '</td><td>' + item.city + '</td></tr>';
				});
				$("#ListTable").append(tablehtml);
			}
		});
	});
}