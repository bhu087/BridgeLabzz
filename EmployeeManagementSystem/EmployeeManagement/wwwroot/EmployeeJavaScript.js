function activeLogin() {
	$(document).ready(function () {
		$("#LoginDiv").show();
	});
	deActiveParagraph();
	deActiveListView();
	deActiveUpdate();
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
	deActiveUpdate();
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
	deActiveUpdate();
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
	deActiveUpdate();
}
function activeUpdateListView() {
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
function activeUpdate() {
	$(document).ready(function () {
		$("#UpdateDiv").show();
	});
	deActiveParagraph();
	deActiveEmployeeManagement();
	deActiveLogin();
	deActiveListView();
}
function deActiveUpdate() {
	$(document).ready(function () {
		$("#UpdateDiv").hide();
	});
}
function clearListView() {
	$(document).ready(function () {
		$("#ListTable").html("");
	});
}
function LoginAction() {
	$(document).ready(function () {
		console.log($("#LoginName").val());
		console.log($("#LoginMobile").val());
		var formData = new FormData;
		formData.append("name", $("#LoginName").val());
		formData.append("mobile", $("#LoginMobile").val());

		console.log(formData);
		$.ajax({
			url: "api/login",
			type: 'POST',
			cache: false,
			contentType: false,
			processData: false,
			data: formData,
			success: function (response) {
				// Replace the div's content with the page method's return.
				alert("Ok");
			},
			error: function (response) {
				alert("Not ok")
			}
		});
	});
}
function UpdateAction() {
	$(document).ready(function () {
		var formData = new FormData;
		formData.append("userId", $("#UpdateId").val());
		formData.append("name", $("#UpdateName").val());
		formData.append("mobile", $("#UpdateMobile").val());
		formData.append("salary", $("#UpdateSalary").val());
		formData.append("city", $("#UpdateCity").val());
		console.log(formData)
		$.ajax({
			url: "api/update",
			type: 'POST',
			cache: false,
			contentType: false,
			processData: false,
			data: formData,
			success: function (response) {
				alert(response);
				GetAllEmployee();
				activeUpdateListView();
			},
			error: function (response) {
				alert("Wrong User Id");
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